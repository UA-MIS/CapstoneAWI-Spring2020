import { Injectable } from '@angular/core';
import { WeatherAPIService } from './weather-api.service';
import { Observable } from 'rxjs';
import { alert } from 'tns-core-modules/ui/dialogs';

@Injectable({
  providedIn: 'root'
})
export class WeatherService {
  currentWeather: Observable<any>;

  constructor(private weatherApiService: WeatherAPIService) { }

  getCurrentWeather(): Observable<any> {
    return this.weatherApiService.getWeatherData();
  }
}
