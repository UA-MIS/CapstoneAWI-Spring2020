import { Component, OnInit } from '@angular/core';
import { WeatherAPIService } from '../shared/weather-api.service';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'Weather',
  templateUrl: './weather.component.html',
  providers: [WeatherAPIService]
})
export class WeatherComponent implements OnInit {
  public currentWeatherData;

  constructor(private weatherService: WeatherAPIService) { }

  ngOnInit() {
    this.getWeatherData();
  }

  getWeatherData() {
    this.weatherService.getCurrentWeatherData(33, -87).subscribe(
      (data) => {
        this.currentWeatherData = data;
        console.log(this.currentWeatherData);
      },
      (err) => console.log(err)
    );
  }
}
