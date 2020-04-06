import { BuoyService } from "../shared/buoy.service";
import { Component, OnInit } from "@angular/core";
import { DataService, DataItem } from "../shared/data.service";
import { map } from "rxjs/operators";
import { MapboxMarker, MapboxViewApi } from "nativescript-mapbox";
import { Observable } from 'rxjs';
import { registerElement } from "nativescript-angular/element-registry";

registerElement("Mapbox", () => require("nativescript-mapbox").MapboxView);

@Component({
    selector: "Home",
    templateUrl: "./home.component.html",
    providers: [BuoyService]
})

export class HomeComponent implements OnInit {
    items: Array<DataItem>;
    buoyData;
    locationData;

    mapbox: MapboxViewApi

    constructor(private _itemService: DataService, private buoyService: BuoyService) { }

    ngOnInit(): void {
        
        this.buoyService.getBuoyData().subscribe(d => {
            this.buoyData = d;
        });
        
        /*
        this.items = this._itemService.getItems();
        */
    }

    onMapReady(args) {
        
        this.mapbox = args.map;
        /*
        this.mapbox.getUserLocation().then(
            function (userLocation) {
                alert("Current user location: " + userLocation.location.lat + ", " + userLocation.location.lng);
                console.log("Current user speed: " + userLocation.speed);
            }
        )
        */
    }

    toggleBuoyMarkers() {

            this.buoyService.getBuoyData().subscribe(el => {
                //get array of buoys
                this.buoyData = el;
                var buoyCount = (this.buoyData.length)-1;

                //loop through array of buoyrs
                var i;
                for (i = 0; i < buoyCount; i++) {
                    // check if buoy is in the gulf of mexico 
                    if (this.buoyData[i].latitude <= 32 && this.buoyData[i].latitude >= 18 
                            && this.buoyData[i].longitude <= -78 && this.buoyData[i].longitude >= -99) {
                        
                        // create temporary variable to hold marker
                        var markerZ = <MapboxMarker>{
                            id: i,
                            lat: this.buoyData[i].latitude,
                            lng: this.buoyData[i].longitude,
                            title: this.buoyData[i].buoyNumber,
                            onTap: marker => console.log("Marker tapped with title: '" + marker.title + "'"),
                            onCalloutTap: marker => alert("Marker callout tapped with title: '" + marker.title + "'" + " Longitude is: '" + marker.lng + "'" + " Latitude is: '" + marker.lat + "'" )
                        }

                        // add marker to mapview
                        this.mapbox.addMarkers([
                            markerZ
                        ])
                    }
                }
            });
    }

    clearMap() {
        this.mapbox.removeMarkers();
    }
}
