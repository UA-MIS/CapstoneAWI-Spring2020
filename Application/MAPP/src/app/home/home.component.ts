import { BuoyService } from "../shared/buoy.service";
import { Component, OnInit } from "@angular/core";
import { DataService, DataItem } from "../shared/data.service";
import { map } from "rxjs/operators";
import { MapboxMarker, MapboxViewApi } from "nativescript-mapbox";
import { Observable } from 'rxjs';
import { registerElement } from "nativescript-angular/element-registry";
import { ModalDialogHost } from "nativescript-angular";
import * as dialogs from "tns-core-modules/ui/dialogs";

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
    document;
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
        
    }

    myFunction() {
    var element = document.getElementById("buoyButton");
    element.classList.remove("greyButton");
    element.classList.add("greyButtonSelected");
    }

    

    toggleBuoyMarkers() {

            this.buoyService.getBuoyData().subscribe(el => {
                //pull array of buoys
                this.buoyData = el;
                var buoyCount = (this.buoyData.length)-1;

                //loop through array of buoys
                var i;
                for (i = 0; i < buoyCount; i++) {
                    // check if buoy is in the gulf of mexico 
                    if (this.buoyData[i].latitude <= 32 && this.buoyData[i].latitude >= 18 
                            && this.buoyData[i].longitude <= -78 && this.buoyData[i].longitude >= -99) {

                        let windDirection: string = '';
                        let waveDirection: string = '';
                        let gustDirection: string = '';
                        let buoyDescription: string = '';

                        if (this.buoyData[i].windDirection != 'MM') {
                            if (this.buoyData[i].windDirection > 11.25 && this.buoyData[i].windDirection <= 33.75) {
                                windDirection = "NNE" + '\n';
                            } else if (this.buoyData[i].windDirection > 33.75 && this.buoyData[i].windDirection < 56.25) {
                                windDirection = "ENE" + '\n';
                            } else if (this.buoyData[i].windDirection > 56.25 && this.buoyData[i].windDirection < 78.75) {
                                windDirection = "E" + '\n';
                            } else if (this.buoyData[i].windDirection > 78.75 && this.buoyData[i].windDirection < 101.25) {
                                windDirection = "ESE" + '\n';
                            } else if (this.buoyData[i].windDirection > 101.25 && this.buoyData[i].windDirection < 123.75) {
                                windDirection = "ESE" + '\n';
                            } else if (this.buoyData[i].windDirection > 123.75 && this.buoyData[i].windDirection < 146.25) {
                                windDirection = "SE" + '\n';
                            } else if (this.buoyData[i].windDirection > 146.25 && this.buoyData[i].windDirection < 168.75) {
                                windDirection = "SSE" + '\n';
                            } else if (this.buoyData[i].windDirection > 168.75 && this.buoyData[i].windDirection < 191.25) {
                                windDirection = "S" + '\n';
                            } else if (this.buoyData[i].windDirection > 191.25 && this.buoyData[i].windDirection < 213.75) {
                                windDirection = "SSW" + '\n';
                            } else if (this.buoyData[i].windDirection > 213.75 && this.buoyData[i].windDirection < 236.25) {
                                windDirection = "SW" + '\n';
                            } else if (this.buoyData[i].windDirection > 236.25 && this.buoyData[i].windDirection < 258.75) {
                                windDirection = "WSW" + '\n';
                            } else if (this.buoyData[i].windDirection > 258.75 && this.buoyData[i].windDirection < 281.25) {
                                windDirection = "W" + '\n';
                            } else if (this.buoyData[i].windDirection > 281.25 && this.buoyData[i].windDirection < 303.75) {
                                windDirection = "WNW" + '\n';
                            } else if (this.buoyData[i].windDirection > 303.75 && this.buoyData[i].windDirection < 326.25) {
                                windDirection = "NW" + '\n';
                            } else if (this.buoyData[i].windDirection > 326.25 && this.buoyData[i].windDirection < 348.75) {
                                windDirection = "NNW" + '\n';
                            } else {
                                windDirection = "N" + '\n';
                            }
                        } else {
                            windDirection = '\n';
                        }
                        if (this.buoyData[i].windSpeed != 'MM' && this.buoyData[i].windSpeed != '0') {
                            buoyDescription = buoyDescription + "Wind: " + this.buoyData[i].windSpeed + " m/s " + windDirection;
                        }
                        if (this.buoyData[i].gustDirection) {
                            gustDirection = this.buoyData[i].gustDirection + '\n';
                        } else {
                            gustDirection = '\n';
                        }
                        if (this.buoyData[i].gustSpeed != 'MM') {
                            buoyDescription = buoyDescription + "Gusts: " + this.buoyData[i].gustSpeed + " m/s " + gustDirection;
                        }
                        if (this.buoyData[i].waveDirection != 'MM') {
                            waveDirection = this.buoyData[i].waveDirection + '\n';
                        } else {
                            waveDirection = '\n';
                        }
                        if (this.buoyData[i].waveHeight != 'MM') {
                            buoyDescription = buoyDescription + "Waves: " + this.buoyData[i].waveHeight + " meters " + waveDirection;
                        }
                        if (this.buoyData[i].airTemperature != 'MM') {
                            buoyDescription = buoyDescription + "Air Temperature: " + this.buoyData[i].airTemperature +"° C" + '\n';
                        }
                        if (this.buoyData[i].waterTemperature != 'MM') {
                            buoyDescription = buoyDescription + "Water Temperature: " + this.buoyData[i].waterTemperature + "° C"  +'\n';
                        }

                        // create temporary variable to hold marker
                        var markerZ = <MapboxMarker>{
                            id: i,
                            lat: this.buoyData[i].latitude,
                            lng: this.buoyData[i].longitude,
                            title: this.buoyData[i].buoyNumber,
                            iconPath: 'app/home/assets/marker12.png',
                            onTap: marker => console.log("Buoy ID: '" + marker.title + "'"),
                            onCalloutTap: marker =>
                                dialogs.alert({
                                    title: "Buoy ID: " + marker.title,
                                    message: "Longitude: '" + marker.lng + "'" + '\n'
                                        + "Latitude: '" + marker.lat + "'" + '\n'
                                        + buoyDescription,
                                    okButtonText: "Okay"
                                }).then(() => {
                                    console.log("Dialog closed!");
                                })
                        }

                        // add marker to mapview
                        this.mapbox.addMarkers([
                            markerZ
                        ])
                    }
                }
            });
    }

    toggleWaves() {
        this.mapbox.removeMarkers();
    }

    toggleWind() {
        this.mapbox.removeMarkers();
    }

    toggleReefs() {
        this.mapbox.removeMarkers();
    }

    toggleWaterTemp() {
        this.mapbox.removeMarkers();
    }

    toggleChlorophyll() {
        this.mapbox.removeMarkers();
    }
    clearMap() {
        this.mapbox.removeMarkers();
    }
}
