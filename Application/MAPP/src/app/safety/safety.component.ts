import { Component, OnInit } from '@angular/core';
import { DataService, DataItem } from "../shared/data.service";

@Component({
  selector: "Safety",
  templateUrl: "./safety.component.html"
  //styleUrls: ['./safety.component.css']
})
export class SafetyComponent implements OnInit {
  items: Array<DataItem>;

  constructor(private _itemService: DataService) { }

  ngOnInit(): void {
    this.items = this._itemService.getItems();
  }

}
