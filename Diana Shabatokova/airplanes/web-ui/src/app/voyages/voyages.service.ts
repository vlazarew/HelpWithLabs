import {Injectable} from '@angular/core';
import {ApiService} from '../api/api.service';
import {storedRow} from "../main-data/main-data.component";
import {Voyage} from "../app.module";

@Injectable({
  providedIn: 'root'
})
export class VoyagesDataService {

  voyagesOnPage: number;
  numberOfPage: number;

  constructor(private apiService: ApiService) {
    this.voyagesOnPage = 10;
    this.numberOfPage = 0;

    this.getVoyagesFromDB(this.voyagesOnPage, this.numberOfPage);
  }

  getVoyagesFromDB(voyagesOnPage: number, numberOfPage: number): any {
    this.voyagesOnPage = voyagesOnPage;
    this.numberOfPage = numberOfPage;

    return this.apiService.get('/voyages?numberOfPage=' + numberOfPage +
      '&voyagesOnPage=' + voyagesOnPage)
  }

  getVoyagesByFromCityToCityFromDate(fromCity: string, toCity: string, date: string, voyagesOnPage: number, numberOfPage: number): any {
    this.voyagesOnPage = voyagesOnPage;
    this.numberOfPage = numberOfPage;

    return this.apiService.get('/voyages?fromCity=' + fromCity +
      '&toCity=' + toCity + '&date=' + date + '&numberOfPage=' + numberOfPage +
      '&voyagesOnPage=' + voyagesOnPage)
  }

  calculateVoyages(storedRows: storedRow[]) {
    let json = JSON.stringify(storedRows);
    return this.apiService.post('/voyages/calculateVoyages', json)
  }
}
