import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { RouterExtensions } from "nativescript-angular/router";
import {openUrl} from "tns-core-modules/utils/utils";
import { DataService, DataItem } from "../../shared/data.service";
import * as dialogs from "tns-core-modules/ui/dialogs";


@Component({
    selector: "ItemDetail",
    templateUrl: "./item-detail.component.html"
})
export class ItemDetailComponent implements OnInit {
    item: DataItem;

    constructor(
        private _data: DataService,
        private _route: ActivatedRoute,
        private _routerExtensions: RouterExtensions
    ) { }

    ngOnInit(): void {
        const id = +this._route.snapshot.params.id;
        this.item = this._data.getItem(id);
    }

    onBackTap(): void {
        this._routerExtensions.back();
    }
    onTap(args) {
        dialogs.confirm({
            title: "This link is trying to leave the application",
            message: "Are you sure you want to leave?",
            okButtonText: "Yes",
            cancelButtonText: "Cancel"
        }).then(r => {
            if(r == true){
                openUrl(this.item.link);
            }
        });
    }  
}
