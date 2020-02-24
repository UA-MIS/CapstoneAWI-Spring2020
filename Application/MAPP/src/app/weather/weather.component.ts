import { Component, OnInit } from '@angular/core';
import { WeatherAPIService } from '../shared/weather-api.service';

@Component({
  selector: 'Weather',
  templateUrl: './weather.component.html',
  providers: [WeatherAPIService]
})
export class WeatherComponent implements OnInit {
  public weatherData;;

  constructor(private weatherService: WeatherAPIService) { }

  ngOnInit() {
    this.weatherService.getWeatherData(33, -87).subscribe(
      (data) => {
        this.weatherData = data;
        console.log(data);
      }, (error) => console.log(error)
    );
  }

}
