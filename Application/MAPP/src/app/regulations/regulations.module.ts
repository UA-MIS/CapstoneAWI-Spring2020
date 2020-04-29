import { NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { NativeScriptCommonModule } from "nativescript-angular/common";

import { RegulationsRoutingModule } from "./regulations-routing.module";
import { RegulationsComponent } from "./regulations.component";

@NgModule({
    imports: [
        NativeScriptCommonModule,
        RegulationsRoutingModule
    ],
    declarations: [
        RegulationsComponent
    ],
    schemas: [
        NO_ERRORS_SCHEMA
    ]
})
export class RegulationsModule { }