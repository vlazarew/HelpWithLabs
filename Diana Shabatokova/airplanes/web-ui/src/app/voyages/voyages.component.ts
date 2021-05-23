import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {ApiService} from "../api/api.service";
import {VoyagesDataService} from "./voyages.service";
import {Voyage} from "../app.module";
import {PageEvent} from "@angular/material/paginator";


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

  displayedColumns: string[] = ['fromCity', 'fromCountry', 'fromTS', 'toCity', 'toCountry', 'toTS', 'price', 'baggagePassed'];

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

  toDate(timestamp: number) {
    return new Date(timestamp * 1000).toLocaleString();
  }
}
