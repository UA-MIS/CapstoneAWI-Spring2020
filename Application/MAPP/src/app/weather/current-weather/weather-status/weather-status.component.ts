import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'ns-weather-status',
  templateUrl: './weather-status.component.html',
  styleUrls: ['./weather-status.component.css']
})
export class WeatherStatusComponent implements OnInit {
  @Input() weatherStatusData;

  constructor() { }

  ngOnInit(): void { }
}
