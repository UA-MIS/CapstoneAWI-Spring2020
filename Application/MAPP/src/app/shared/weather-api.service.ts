import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class WeatherAPIService {;
  constructor(private http: HttpClient) { }

  getCurrentWeatherData(lat: number, lon: number): Observable<any> {
    let key = "a820e83b00a7f25dc38c83c6d42fdeee";
    let headers = new HttpHeaders({
      'Content-Type': 'application/json'
    });
    return this.http.get(
      `https://api.openweathermap.org/data/2.5/weather?lat=${lat}&lon=${lon}&appid=${key}`, 
      { headers: headers }
    );
  }
}
