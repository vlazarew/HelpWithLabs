import {Component, Injectable, OnInit} from '@angular/core';
import {HttpClient, HttpHeaders} from "@angular/common/http";

export const urlDB = 'http://localhost:8080/';

@Injectable({
  providedIn: 'root'
})

export class ApiService {

  constructor(private httpClient: HttpClient) {
  }

  get(path: string) {
    return this.httpClient.get(urlDB + path);
  }

  post(path: string, body: any) {
    const myHeaders = new HttpHeaders().set('Access-Control-Allow-Origin', '*').set('Content-Type', 'application/json; charset=utf-8');
    return this.httpClient.post(urlDB + path, body, {headers: myHeaders});
  }

}
