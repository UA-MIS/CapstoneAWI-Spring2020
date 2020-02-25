import { Component, OnInit } from '@angular/core';
import { WeatherAPIService } from '../../shared/weather-api.service';

@Component({
  selector: 'ns-current-weather',
  templateUrl: './current-weather.component.html',
  styleUrls: ['./current-weather.component.css']
})
export class CurrentWeatherComponent implements OnInit {
  public currentWeatherData;

  constructor(private weatherService: WeatherAPIService) { }

  ngOnInit(): void {
    this.getCurrentWeatherData();
  }

  getCurrentWeatherData() {
    this.weatherService.getCurrentWeatherData(25.36, -91.51).subscribe(
      (data) => {
        this.currentWeatherData = data;
        console.log(data);
      },
      (err) => console.log(err)
    );
  }
}
