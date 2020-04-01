import { Component, OnInit } from "@angular/core";

import { DataService, DataItem } from "../shared/data.service";
import { BuoyService } from "../shared/buoy.service";

@Component({
    selector: "Home",
    templateUrl: "./home.component.html",
    providers: [BuoyService]
})
export class HomeComponent implements OnInit {
    items: Array<DataItem>;
    buoyData;

    constructor(private _itemService: DataService, private buoyService: BuoyService) { }

    ngOnInit(): void {
        this.buoyService.getBuoyData().subscribe(d => {
            this.buoyData = d;
            console.log(this.buoyData[0]);
        });
        this.items = this._itemService.getItems();
    }
}
