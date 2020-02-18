import { Component, OnInit } from '@angular/core';
import { WeatherService } from '../shared/weather.service';

@Component({
  selector: 'Weather',
  templateUrl: './weather.component.html',
})
export class WeatherComponent implements OnInit {
  public data = { title: "placeHolder" };

  constructor(private weatherService: WeatherService) { }

  ngOnInit(): void {
    this.weatherService.getCurrentWeather().subscribe(
      data => this.data = data,
      err => {
        console.log(err);
      }
    );
  }

}
