import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import * as geolocation from "nativescript-geolocation";
import { Accuracy } from "tns-core-modules/ui/enums";


@Injectable({
  providedIn: 'root'
})
export class GeolocationService {
  public currentLocation = new BehaviorSubject({});
  private watchId;

  constructor() { }

  clearWatch() {
    if (this.watchId) {
      geolocation.clearWatch(this.watchId);
      this.watchId = null;
    }
  }

  watchLocation() {
    // Ask for location permissions if the app doesn't already have them
    geolocation.enableLocationRequest(false, true).then(() => {
      // Watch for changes in the user's location and update BehaviorSubject accordingly
      this.watchId = geolocation.watchLocation(
        loc => {
          this.currentLocation.next(loc);
        },
        e => {
          console.log("Error occured while updating location: ", e);
        },
        {
          desiredAccuracy: Accuracy.any,
          updateDistance: 1.0,
          updateTime: 3000,
          minimumUpdateTime: 100
        }
      )
    }, e => {
      console.log("Error enabling location services: ", e);
    });
  }
}
