import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';

import { WeatherRoutingModule } from './weather-routing.module';
import { NativeScriptCommonModule } from 'nativescript-angular/common';
import { WeatherComponent } from './weather.component';


@NgModule({
  declarations: [WeatherComponent],
  imports: [
    WeatherRoutingModule,
    NativeScriptCommonModule
  ],
  schemas: [NO_ERRORS_SCHEMA]
})
export class WeatherModule { }
