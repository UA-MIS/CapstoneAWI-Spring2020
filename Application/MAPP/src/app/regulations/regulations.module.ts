import { NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { NativeScriptCommonModule } from "nativescript-angular/common";

import { RegulationsRoutingModule } from "./regulations-routing.module";
import { RegulationsComponent } from "./regulations.component";
import { ItemDetailComponent } from "./item-detail/item-detail.component";


@NgModule({
    imports: [
        NativeScriptCommonModule,
        RegulationsRoutingModule
    ],
    declarations: [
        RegulationsComponent,
        ItemDetailComponent
    ],
    schemas: [
        NO_ERRORS_SCHEMA
    ]
})
export class RegulationsModule { }
