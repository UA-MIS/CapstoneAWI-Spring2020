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
        
        this.mapbox.addMarkers([
            <MapboxMarker>{
                id: 1,
                lat: 25,
                lng: -90.5,
                title: '15',
                iconPath: 'app/home/assets/marker15.png',
                onTap: marker => console.log("Buoy ID: '" + marker.title + "'"),
                onCalloutTap: marker => alert("please work")
            },
            <MapboxMarker>{
                id: 1,
                lat: 24.7,
                lng: -90.1,
                title: '20',
                iconPath: 'app/home/assets/marker20.png',
                onTap: marker => console.log("Buoy ID: '" + marker.title + "'"),
                onCalloutTap: marker => alert("please work")
            },
            <MapboxMarker>{
                id: 1,
                lat: 24.3,
                lng: -89.8,
                title: '8',
                iconPath: 'app/home/assets/marker8.png',
                onTap: marker => console.log("Buoy ID: '" + marker.title + "'"),
                onCalloutTap: marker => alert("please work")
            },
            <MapboxMarker>{
                id: 1,
                lat: 24,
                lng: -89.5,
                title: 'Test Marker',
                iconPath: 'app/home/assets/blackMarker14px.png',
                onTap: marker => console.log("Buoy ID: '" + marker.title + "'"),
                onCalloutTap: marker => alert("please work")
            },
            <MapboxMarker>{
                id: 1,
                lat: 23.5,
                lng: -89,
                title: '12',
                iconPath: 'app/home/assets/marker12.png',
                onTap: marker => console.log("Buoy ID: '" + marker.title + "'"),
                onCalloutTap: marker => alert("please work")
            },
        ])
        */
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
                            windDirection = this.buoyData[i].windDirection + '\n';
                        } else {
                            windDirection = '\n';
                        }
                        if (this.buoyData[i].windSpeed != 'MM') {
                            buoyDescription = buoyDescription + "Wind: " + this.buoyData[i].windSpeed + windDirection;
                        }
                        if (this.buoyData[i].gustDirection) {
                            gustDirection = this.buoyData[i].gustDirection + '\n';
                        } else {
                            gustDirection = '\n';
                        }
                        if (this.buoyData[i].gustSpeed != 'MM') {
                            buoyDescription = buoyDescription + "Gusts: " + this.buoyData[i].gustSpeed + " " + gustDirection;
                        }
                        if (this.buoyData[i].waveDirection != 'MM') {
                            waveDirection = this.buoyData[i].waveDirection + '\n';
                        } else {
                            waveDirection = '\n';
                        }
                        if (this.buoyData[i].waveHeight != 'MM') {
                            buoyDescription = buoyDescription + "Waves: " + this.buoyData[i].waveHeight + " " + waveDirection;
                        }
                        if (this.buoyData[i].airTemperature != 'MM') {
                            buoyDescription = buoyDescription + "Air Temperature: " + this.buoyData[i].airTemperature + '\n';
                        }
                        if (this.buoyData[i].waterTemperature != 'MM') {
                            buoyDescription = buoyDescription + "Water Temperature: " + this.buoyData[i].waterTemperature + '\n';
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
                                alert("Buoy ID: '" + marker.title + "'" + '\n'
                                    + " Longitude: '" + marker.lng + "'" + '\n'
                                    + " Latitude: '" + marker.lat + "'" + '\n'
                                    + buoyDescription)
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
