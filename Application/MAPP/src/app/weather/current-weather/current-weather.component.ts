import { Component, OnInit } from '@angular/core';
import { WeatherAPIService } from '../../shared/weather-api.service';
import { fontStyleProperty } from 'tns-core-modules/ui/page/page';

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
    this.weatherService.getCurrentWeatherData(32, -86).subscribe(
      (data) => {
        this.currentWeatherData = data;
        console.log(data);
      },
      (err) => console.log(err)
    );
  }

  convertKelvinToFahrenheit(temp: number): number {
    return Math.floor((temp - 273.15) * 9/5 + 32);
  }
}
