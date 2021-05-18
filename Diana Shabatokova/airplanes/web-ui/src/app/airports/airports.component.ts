import {Component, OnInit} from '@angular/core';
import {PageEvent} from "@angular/material/paginator";
import {HttpClient} from "@angular/common/http";
import {Router} from "@angular/router";
import {ApiService} from "../api/api.service";
import {AirportDataService} from "./airports.service";

export class Airport {
  constructor(public city: string,
              public country: string,
              public name: string,
              public shortName: string) {
  }
}

@Component({
  selector: 'app-airports',
  templateUrl: './airports.component.html',
  styleUrls: ['./airports.component.less']
})
export class AirportsComponent implements OnInit {

  airports: Airport[];
  countOfAirports: number;
  countOfPages: number;

  pageSize: number;
  pageIndex: number;

  displayedColumns: string[] = ['city', 'country', 'name', 'code'];

  constructor(private httpClient: HttpClient,
              private router: Router,
              private apiService: ApiService,
              private airportsDataService: AirportDataService) {
    this.pageSize = 10;
    this.pageIndex = 0;
    this.countOfAirports = 0;
    this.countOfPages = 0;
    this.airports = [];
  }

  ngOnInit(): void {
    this.getAirports();
  }

  getAirports() {
    this.airportsDataService.getAirportsFromDB(this.pageSize, this.pageIndex).subscribe(
      (response: any) => {
        this.airports = response[0];
        this.countOfAirports = response[1];
        this.countOfPages = response[2];
      }
    )
  }

  setPageSizeOptions($event: PageEvent) {
    this.pageSize = $event.pageSize;
    this.pageIndex = $event.pageIndex;

    this.airportsDataService.getAirportsFromDB(this.pageSize, this.pageIndex);
    this.getAirports();
  }
}
