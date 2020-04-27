import { BuoyService } from "../shared/buoy.service";
import { Component, OnInit, ViewChild, ViewContainerRef } from "@angular/core";
import { DataService, DataItem } from "../shared/data.service";
import { map } from "rxjs/operators";
import { Observable } from "tns-core-modules/data/observable";
import { registerElement } from "nativescript-angular/element-registry";
import { ModalDialogHost } from "nativescript-angular";
import * as dialogs from "tns-core-modules/ui/dialogs";
import { Mapbox, MapStyle, OfflineRegion, LatLng, Viewport, DownloadProgress, MapboxMarker, MapboxViewApi, MapboxView } from "nativescript-mapbox";
import * as platform from "tns-core-modules/platform";

registerElement("Mapbox", () => require("nativescript-mapbox").MapboxView);
const isIOS = platform.device.os === platform.platformNames.ios;
const ACCESS_TOKEN = "sk.eyJ1IjoiYXdpbWFwcCIsImEiOiJjazkwMWxtamEwMDBhM2hwdXF5dmlkaTlpIn0.4we_OHFl1VMXDbpJ0tq48A";
const MAP_STYLE = "mapbox://styles/awimapp/ck901qzms0xwq1iqgdg61jijj"

@Component({
    selector: "Home",
    templateUrl: "./home.component.html",
    providers: [BuoyService]
})

export class HomeComponent implements OnInit {
  private mapbox: Mapbox;
  private mapView = new MapboxView();

  constructor() {
    //super();
    this.mapbox = new Mapbox();
  }
    ngOnInit(): void {
      throw new Error("Method not implemented.");
    }

    @ViewChild( 'mapContainer', { read: ViewContainerRef, static: false }) mapContainer;

    public mapboxView: MapboxViewApi = null;
    public mapboxApi: Mapbox = null;

  public doShow(): void {
    this.mapbox.show({
      accessToken: ACCESS_TOKEN,
      //Style will need to be adjusted based on existing AWI Mapbox Account
      style: MapStyle.TRAFFIC_DAY,
      //Margins will need to be adjusted
      margins: {
        left: 18,
        right: 18,
        top: isIOS ? 390 : 454,
        bottom: isIOS ? 50 : 8
      },
      //(24.5, -90) for Gulf of Mexico
      center: {
        lat: 24.5,
        lng: -90
      },
      //Made need to adjust some settings 
      zoomLevel: 3.5, // 0 (most of the world) to 20, default 0
      showUserLocation: true, // default false
      hideAttribution: true, // default false
      hideLogo: true, // default false
      hideCompass: false, // default false
      disableRotation: false, // default false
      disableScroll: false, // default false
      disableZoom: false, // default false
      disableTilt: false, // default false
      //Placeholder marker to be replaced by existing ones
      markers: [
        {
          id: 1,
          lat: 52.3732160,
          lng: 4.8941680,
          title: 'Nice location',
          subtitle: 'Really really nice location',
          iconPath: 'res/markers/green_pin_marker.png',
          onTap: () => console.log("'Nice location' marker tapped"),
          onCalloutTap: () => console.log("'Nice location' marker callout tapped")
        }
      ]
    }).then(
        //Supposed to display programatically declared map view, see 'Future Project Enhancements'
        showResult => {
          console.log(`Mapbox show done for ${showResult.ios ? "iOS" : "Android"}, native object received: ${showResult.ios ? showResult.ios : showResult.android}`);

          this.mapbox.setOnMapClickListener(point => console.log(`>> Map clicked: ${JSON.stringify(point)}`));

          this.mapbox.setOnScrollListener((point: LatLng) => {
            // console.log(`>> Map scrolled: ${JSON.stringify(point)}`);
          });

          this.mapbox.setOnFlingListener(() => {
            console.log(`>> Map flinged"}`);
          }).catch(err => console.log(err));
        },
        (error: string) => console.log("mapbox show error: " + error)
    );
  }


//These functions currently remove markers but should also toggle between overlays when finished
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

