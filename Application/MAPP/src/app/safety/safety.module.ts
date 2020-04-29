import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { NativeScriptCommonModule } from 'nativescript-angular/common';
import { SafetyRoutingModule } from "./safety-routing.module";
import { SafetyComponent } from "./safety.component";
import { ItemDetailComponent } from "../safety/item-detail/item-detail.component";

@NgModule({
  declarations: [
    SafetyComponent,
    ItemDetailComponent
  ],
  imports: [
    NativeScriptCommonModule,
    SafetyRoutingModule
  ],
  schemas: [NO_ERRORS_SCHEMA]
})
export class SafetyModule { }