import { NgModule } from "@angular/core";
import { Routes } from "@angular/router";
import { NSEmptyOutletComponent } from "nativescript-angular";
import { NativeScriptRouterModule } from "nativescript-angular/router";

const routes: Routes = [
    {
        path: "",
        redirectTo: "/(homeTab:home/default//browseTab:browse/default//safetyTab:safety/default)",
        pathMatch: "full"
    },
    {
        path: "home",
        component: NSEmptyOutletComponent,
        loadChildren: () => import("~/app/home/home.module").then((m) => m.HomeModule),
        outlet: "homeTab"
    },
    {
        path: "weather",
        component: NSEmptyOutletComponent,
        loadChildren: () => import("~/app/weather/weather.module").then((m) => m.WeatherModule),
        outlet: "weatherTab"
    },
    {
        path: "safety",
        component: NSEmptyOutletComponent,
        loadChildren: () => import("~/app/safety/safety.module").then((m) => m.SafetyModule),
        outlet: "safetyTab"
    },
    {
        path: "regulations",
        component: NSEmptyOutletComponent,
        loadChildren: () => import("~/app/regulations/regulations.module").then((m) => m.RegulationsModule),
        outlet: "regulationsTab"
    }
];

@NgModule({
    imports: [NativeScriptRouterModule.forRoot(routes)],
    exports: [NativeScriptRouterModule]
})
export class AppRoutingModule { }
