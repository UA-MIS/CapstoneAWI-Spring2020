import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
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
      // Parse text into JSON here
      return d;
    }))
  }
}
