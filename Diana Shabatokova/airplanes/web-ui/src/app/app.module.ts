import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';

import {AppRoutingModule} from './app-routing.module';
import {AppComponent} from './app.component';
import {FooterComponent} from './footer/footer.component';
import {HeaderComponent} from './header/header.component';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MainDataComponent} from './main-data/main-data.component';
import {MatTableModule} from '@angular/material/table';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatIconModule} from '@angular/material/icon';
import {MatPaginatorIntl, MatPaginatorModule} from '@angular/material/paginator';
import {MatTabsModule} from '@angular/material/tabs';
import {AirportsComponent} from './airports/airports.component';
import {VoyagesComponent} from './voyages/voyages.component';
import {HttpClientModule} from '@angular/common/http';


import {FormsModule, ReactiveFormsModule} from '@angular/forms';

import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';

import {MatAutocompleteModule} from '@angular/material/autocomplete';
import {MatDatepickerModule} from "@angular/material/datepicker";
import {MAT_DATE_LOCALE, MatNativeDateModule} from "@angular/material/core";
import {MatSelectModule} from "@angular/material/select";
import {DatePipe} from "@angular/common";
import {MatChipsModule} from "@angular/material/chips";


@NgModule({
  declarations: [
    AppComponent,
    FooterComponent,
    HeaderComponent,
    MainDataComponent,
    AirportsComponent,
    VoyagesComponent
  ],
  imports: [
    AppRoutingModule,
    MatTableModule,
    MatMenuModule,
    MatButtonModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonToggleModule,
    MatPaginatorModule,
    MatTabsModule,
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatAutocompleteModule,
    FormsModule,
    ReactiveFormsModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatSelectModule
  ],
  providers: [{provide: MatPaginatorIntl}, {provide: MAT_DATE_LOCALE, useValue: 'ru-RU'}, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule {
}

export class Country {
  constructor(public name: string) {
  }
}

export class City {
  constructor(public name: string,
              public country: Country) {
  }
}

export class Airport {
  constructor(public city: City,
              public name: string,
              public shortName: string) {
  }
}

export class Voyage {
  constructor(public baggagePassed: boolean,
              public fromTS: number,
              public price: number,
              public toTS: number,
              public from: Airport,
              public to: Airport) {
  }
}
