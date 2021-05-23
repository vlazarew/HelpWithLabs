import {Injectable} from '@angular/core';
import {HttpClient} from '@angular/common/http';
import {map} from 'rxjs/operators'
import {ApiService} from "../api/api.service";

@Injectable({
  providedIn: 'root'
})
export class AutoFillerService {

  constructor(private apiService: ApiService) {
  }

  getData() {
    return this.apiService.get('/cities')
      .pipe(map((response: any) => response.map((item: { [x: string]: any; }) => item['name'])))
  }
}
