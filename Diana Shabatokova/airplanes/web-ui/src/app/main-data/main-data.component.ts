import {Component, OnInit} from '@angular/core';
import {AutoFillerService} from "./autoFiller.service";
import {FormBuilder, FormGroup, Validators} from "@angular/forms";


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
  options: string[];
  filteredOptionsFrom: string[];
  filteredOptionsTo: string[];
  formGroupTo: FormGroup;
  formGroupFrom: FormGroup;

  constructor(private service: AutoFillerService,
              private fb: FormBuilder) {
    this.filteredOptionsFrom = [];
    this.filteredOptionsTo = [];
    this.options = [];
    this.formGroupTo = fb.group({title: fb.control('initial value', Validators.required)});
    this.formGroupFrom = fb.group({title: fb.control('initial value', Validators.required)});
  }

  ngOnInit(): void {
    this.initForm();
    this.getNames();
  }

  initForm() {
    this.formGroupFrom = this.fb.group({
      'fromCity': ['']
    })

    this.formGroupTo = this.fb.group({
      'toCity': ['']
    })


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
      // this.filteredOptions = response;
    })
  }

}
