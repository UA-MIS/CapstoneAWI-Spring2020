import { Component, OnInit } from "@angular/core";

import { DataService, DataItem } from "../shared/data.service";

@Component({
    selector: "Search",
    templateUrl: "./search.component.html"
})
export class SearchComponent implements OnInit {
    items: Array<DataItem>;

    constructor(private _itemService: DataService) { }

    ngOnInit(): void {
        this.items = this._itemService.getItems();
    }
}


 