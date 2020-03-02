import { Component, OnInit } from "@angular/core";
import { GeolocationService } from "./shared/geolocation.service";

@Component({
    selector: "ns-app",
    templateUrl: "app.component.html"
})
export class AppComponent implements OnInit {

    constructor(private geolocationService: GeolocationService) {
        geolocationService.watchLocation();
    }

    ngOnInit(): void {
        // Init your component properties here.
    }
}
