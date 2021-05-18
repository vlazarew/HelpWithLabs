import {Injectable} from '@angular/core';
import {ApiService} from '../api/api.service';

@Injectable({
  providedIn: 'root'
})
export class AirportDataService {

  airportsOnPage: number;
  numberOfPage: number;

  constructor(private apiService: ApiService) {
    this.airportsOnPage = 10;
    this.numberOfPage = 0;

    this.getAirportsFromDB(this.airportsOnPage, this.numberOfPage);
  }

  getAirportsFromDB(airportsOnPage: number, numberOfPage: number): any {
    this.airportsOnPage = airportsOnPage;
    this.numberOfPage = numberOfPage;

    return this.apiService.get('/airports?numberOfPage=' + numberOfPage +
      '&airportsOnPage=' + airportsOnPage)
  }
}
