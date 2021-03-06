import {Component, OnInit} from '@angular/core';
import {AutoFillerService} from "./autoFiller.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";
import {VoyagesDataService} from "../voyages/voyages.service";
import {PageEvent} from "@angular/material/paginator";
import {DatePipe} from "@angular/common";
import {Voyage} from "../app.module";

export interface getModel {
  from: string;
  to: string;
  date: string;
}

export interface storedRow {
  cityFrom: string;
  cityTo: string;
  voyages: Voyage[]
}

export interface calculatedPrice {
  index: number;
  price: number;
}

@Component({
  selector: 'app-main-data',
  templateUrl: './main-data.component.html',
  styleUrls: ['./main-data.component.less']
})
export class MainDataComponent implements OnInit {
  options: string[];
  filteredOptionsFrom: string[];
  filteredOptionsTo: string[];
  formGroupTo: FormGroup;
  formGroupFrom: FormGroup;
  autoNationality: any;

  model: getModel;

  foundedVoyages: Voyage[];

  countOfVoyages: number;
  countOfPages: number;

  pageSize: number;
  pageIndex: number;

  selectedRows: Voyage[];
  storedRows: storedRow[];
  calculatedWays: [Voyage[]];
  calculatedPrices: calculatedPrice[];


  constructor(private service: AutoFillerService,
              private fb: FormBuilder,
              private voyageService: VoyagesDataService,
              public datepipe: DatePipe) {
    this.filteredOptionsFrom = [];
    this.filteredOptionsTo = [];
    this.options = [];
    this.selectedRows = [];
    this.storedRows = [];
    this.calculatedWays = [[]];
    this.calculatedPrices = [];
    this.model = {from: '', date: '', to: ''}
    this.formGroupTo = fb.group({
      toCity: [this.model.to, [Validators.required, Validators.minLength(1)]]
    })
    this.formGroupFrom = fb.group({
      fromCity: [this.model.from, [Validators.required, Validators.minLength(1)]]
    })
    this.foundedVoyages = []
    this.pageSize = 10;
    this.pageIndex = 0;
    this.countOfVoyages = 0;
    this.countOfPages = 0;
  }

  displayedColumns: string[] = ['fromCity', 'fromCountry', 'fromTS', 'toCity', 'toCountry', 'toTS', 'price', 'baggagePassed'];


  ngOnInit(): void {
    this.initForm();
    this.getNames();
  }

  initForm() {
    this.formGroupFrom.get('fromCity')?.valueChanges.subscribe(response => {
      this.filterFromCity(response);
    })

    this.formGroupTo.get('toCity')?.valueChanges.subscribe(response => {
      this.filterToCity(response);
    })
  }

  filterFromCity(enteredData: string) {
    this.filteredOptionsFrom = this.options.filter(item => {
      return item.toLowerCase().indexOf(enteredData.toLowerCase()) > -1
    })
  }

  filterToCity(enteredData: string) {
    this.filteredOptionsTo = this.options.filter(item => {
      return item.toLowerCase().indexOf(enteredData.toLowerCase()) > -1
    })
  }

  getNames() {
    this.service.getData().subscribe((response: string[]) => {
      this.options = response;
    })
  }

  getVoyagesByFromToDate() {
    let check = this.validateForm();
    if (!check) {
      return;
    }

    this.selectedRows = [];
    this.getVoyages();
  }

  getVoyages() {
    let latest_date = this.datepipe.transform(this.model.date, 'dd.MM.yyyy');
    if (latest_date != null) {
      this.voyageService.getVoyagesByFromCityToCityFromDate(this.model.from, this.model.to, latest_date, this.pageSize, this.pageIndex).subscribe((response: any) => {
        this.foundedVoyages = response[0];
        this.countOfVoyages = response[1];
        this.countOfPages = response[2];
      });
    }
  }

  setPageSizeOptions($event: PageEvent) {
    this.pageSize = $event.pageSize;
    this.pageIndex = $event.pageIndex;

    this.getVoyages();
  }

  validateForm(): boolean {
    let check = true;
    if (this.formGroupFrom.invalid) {
      this.formGroupFrom.get('fromCity')?.markAsTouched();
      check = false;
    }

    if (this.formGroupTo.invalid) {
      this.formGroupTo.get('toCity')?.markAsTouched();
      check = false;
    }

    return check;
  }

  onRowClick(row: Voyage) {
    let neededIndex = this.selectedRows.indexOf(row);
    if (neededIndex != -1) {
      this.selectedRows.splice(neededIndex, 1);
    } else {
      this.selectedRows.push(row);
    }
  }

  selectNextVoyage() {
    this.storedRows.push({cityFrom: this.model.from, cityTo: this.model.to, voyages: this.selectedRows})
    this.selectedRows = []
    this.model.from = this.model.to
    this.model.to = ''
    this.model.date = ''
    this.foundedVoyages = []
  }

  calculateVoyages() {
    this.selectNextVoyage();
    this.voyageService.calculateVoyages(this.storedRows).subscribe((response: any) => {
        this.calculatedWays = response;
        let index = 0;
        response.forEach((way: any) => {
          let price = 0;

          way.forEach((voyage: any) => {
            price += voyage.price
          })
          this.calculatedPrices.push({price: price, index: index});
          index++;
        })

        this.calculatedPrices.sort((a, b) => a.price > b.price ? 1 : -1);
        console.log(this.calculatedPrices)
    }
    )
  }

  toDate(timestamp: number) {
    return new Date(timestamp * 1000).toLocaleString();
  }
}
