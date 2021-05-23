import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {MainDataComponent} from "./main-data/main-data.component";
import {CommonModule} from "@angular/common";
import {VoyagesComponent} from "./voyages/voyages.component";
import {AirportsComponent} from "./airports/airports.component";

const routes: Routes = [
  {path: 'home', component: MainDataComponent},
  {path: 'voyages', component: VoyagesComponent},
  {path: 'airports', component: AirportsComponent},
  {path: '**', redirectTo: 'home', pathMatch: 'full'}
];

@NgModule({
  imports: [CommonModule, RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
