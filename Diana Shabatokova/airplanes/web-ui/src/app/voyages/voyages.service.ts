import {Injectable} from '@angular/core';
import {ApiService} from '../api/api.service';

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
}
