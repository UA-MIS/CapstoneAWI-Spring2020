import { NgModule } from "@angular/core";
import { Routes } from "@angular/router";
import { NSEmptyOutletComponent } from "nativescript-angular";
import { NativeScriptRouterModule } from "nativescript-angular/router";

const routes: Routes = [
    {
        path: "",
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
        redirectTo: "/(homeTab:home/default//browseTab:browse/default//safetyTab:safety/default)",
=======
        redirectTo: "/(homeTab:home/default//browseTab:browse/default//searchTab:search/default//regulationsTab:regulations/default)",
>>>>>>> parent of 9b8ac2c... Adding images to safety
=======
        redirectTo: "/(homeTab:home/default//browseTab:browse/default//searchTab:search/default//regulationsTab:regulations/default)",
>>>>>>> parent of 9b8ac2c... Adding images to safety
=======
        redirectTo: "/(homeTab:home/default//browseTab:browse/default//searchTab:search/default)",
>>>>>>> parent of 6350f60... Safety Tab Re-routing Test
        pathMatch: "full"
    },

    {
        path: "home",
        component: NSEmptyOutletComponent,
        loadChildren: () => import("~/app/home/home.module").then((m) => m.HomeModule),
        outlet: "homeTab"
    },
    {
        path: "browse",
        component: NSEmptyOutletComponent,
        loadChildren: () => import("~/app/browse/browse.module").then((m) => m.BrowseModule),
        outlet: "browseTab"
    },
    {
        path: "search",
        component: NSEmptyOutletComponent,
        loadChildren: () => import("~/app/search/search.module").then((m) => m.SearchModule),
        outlet: "searchTab"
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
