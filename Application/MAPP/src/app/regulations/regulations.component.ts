import { Component, OnInit } from '@angular/core';
import { DataService, DataItem } from "../shared/data.service";

@Component({
  selector: 'ns-regulations',
  templateUrl: './regulations.component.html',
})
export class RegulationsComponent implements OnInit {

  items: Array<DataItem>;

    constructor(private _itemService: DataService) { }

    ngOnInit(): void {
        this.items = this._itemService.getRegulations();
    }

}
