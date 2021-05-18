import {Component, OnInit} from '@angular/core';

export interface Voyages {
  position: number;
  from: string;
  fromCode: string;
  to: string;
  toCode: string;
  price: number;
  start: number;
  end: number;
}

@Component({
  selector: 'app-main-data',
  templateUrl: './main-data.component.html',
  styleUrls: ['./main-data.component.less']
})
export class MainDataComponent implements OnInit {

  constructor() {
  }

  ngOnInit(): void {
  }

}
