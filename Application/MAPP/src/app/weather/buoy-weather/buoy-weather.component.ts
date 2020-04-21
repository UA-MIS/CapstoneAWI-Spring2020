import { Component, OnInit, Input } from '@angular/core';
import { BuoyService } from '../../shared/buoy.service';

@Component({
  selector: 'ns-buoy-weather',
  templateUrl: './buoy-weather.component.html',
  styleUrls: ['./buoy-weather.component.css'],
  providers: [BuoyService]
})
export class BuoyWeatherComponent implements OnInit {
  @Input() buoyIndex: string;
  buoyData;

  constructor(private buoyService: BuoyService) { }

  ngOnInit(): void {
    this.buoyService.getBuoyData().subscribe(d => {
      this.buoyData = d[this.buoyIndex];
    });
  }
  

}
