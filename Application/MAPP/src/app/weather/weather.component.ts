import { Component, OnInit } from '@angular/core';
import { WeatherAPIService } from '../shared/weather-api.service';

@Component({
  selector: 'Weather',
  templateUrl: './weather.component.html',
  providers: [WeatherAPIService]
})
export class WeatherComponent implements OnInit {
  constructor() { }

  ngOnInit() { }
}
