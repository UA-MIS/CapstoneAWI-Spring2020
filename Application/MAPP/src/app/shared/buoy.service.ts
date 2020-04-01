import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BuoyService {
  constructor(private http: HttpClient) { }

  getRawBuoyData(): Observable<any> {
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.get(
      "https://www.ndbc.noaa.gov/data/latest_obs/latest_obs.txt",
      { responseType: 'text' }
    );
  }

  getBuoyData(): Observable<any> {
    return this.getRawBuoyData().pipe(map(d => {
      let buoys = [];
      let lines = d.split('\n');
      // Use the headers in the files as JSON column labels? Would allow for cleaner code
      // Parse each line of text into a JSON object representing a buoy
      for (let i = 2; i < lines.length; i++) {
        let buoy = {};
        let data = lines[i].replace(/ +(?= )/g,'').split(" ");

        buoy['buoyNumber'] = data[0];
        buoy['latitude'] = data[1];
        buoy['longitude'] = data[2];
        buoy['updateYear'] = data[3];
        buoy['updateMonth'] = data[4];
        buoy['updateDay'] = data[5];
        buoy['updateHour'] = data[6];
        buoy['updateMinute'] = data[7];
        buoy['windDirection'] = data[8];
        buoy['windSpeed'] = data[9];
        buoy['gustSpeed'] = data[10];
        buoy['waveHeight'] = data[11];
        buoy['dominantWavePeriod'] = data[12];
        buoy['averageWavePeriod'] = data[13];
        buoy['waveDirection'] = data[14];
        buoy['pressure'] = data[15];
        buoy['airTemperature'] = data[16];
        buoy['waterTemperature'] = data[17];
        buoy['dewPoint'] = data[18];
        buoy['visibility'] = data[19];
        buoy['pressureTendency'] = data[20];
        buoy['tide'] = data[21];

        buoys.push(buoy);
      }
      return buoys;
    }))
  }
}
