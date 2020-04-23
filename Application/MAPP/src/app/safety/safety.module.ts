import { NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { NativeScriptCommonModule } from "nativescript-angular/common";

import { SafetyRoutingModule } from "./safety-routing.module";
import { SafetyComponent } from "./safety.component";

@NgModule({
    imports: [
        NativeScriptCommonModule,
        SafetyRoutingModule
    ],
    declarations: [
        SafetyComponent
    ],
    schemas: [
        NO_ERRORS_SCHEMA
    ]
})
export class SafetyModule { }