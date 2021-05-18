import {Component, OnInit} from '@angular/core';
import {PageEvent} from "@angular/material/paginator";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {ApiService} from "../api/api.service";
import {Airport} from "../airports/airports.component";
import {VoyagesDataService} from "./voyages.service";

export class Voyage {
  constructor(public baggagePassed: boolean,
              public fromDate: string,
              public fromTime: string,
              public price: number,
              public toDate: string,
              public toTime: string,
              public from: Airport,
              public to: Airport) {
  }
}

@Component({
  selector: 'app-voyages',
  templateUrl: './voyages.component.html',
  styleUrls: ['./voyages.component.less']
})
export class VoyagesComponent implements OnInit {

  voyages: Voyage[];
  countOfVoyages: number;
  countOfPages: number;

  pageSize: number;
  pageIndex: number;

  displayedColumns: string[] = ['fromCity', 'fromCountry', 'fromDate', 'fromTime', 'toCity', 'toCountry', 'toDate', 'toTime', 'price', 'baggagePassed'];

  constructor(private httpClient: HttpClient,
              private router: Router,
              private apiService: ApiService,
              private voyagesDataService: VoyagesDataService) {
    this.pageSize = 10;
    this.pageIndex = 0;
    this.countOfVoyages = 0;
    this.countOfPages = 0;
    this.voyages = [];
  }

  ngOnInit(): void {
    this.getVoyages();
  }

  getVoyages() {
    this.voyagesDataService.getVoyagesFromDB(this.pageSize, this.pageIndex).subscribe(
      (response: any) => {
        console.log(response);
        this.voyages = response[0];
        this.countOfVoyages = response[1];
        this.countOfPages = response[2];
      }
    )
  }

  setPageSizeOptions($event: PageEvent) {
    this.pageSize = $event.pageSize;
    this.pageIndex = $event.pageIndex;

    this.voyagesDataService.getVoyagesFromDB(this.pageSize, this.pageIndex);
    this.getVoyages();
  }
}
