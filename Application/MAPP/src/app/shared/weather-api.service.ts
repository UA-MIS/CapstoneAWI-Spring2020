import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class WeatherAPIService {
  constructor(private http: HttpClient) { }

  getWeatherData() {
    return this.http.get('https://jsonplaceholder.typicode.com/todos/1');
  }
}
