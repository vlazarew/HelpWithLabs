import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.less']
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router) { }

  ngOnInit(): void {
    console.log("url is " + this.router.url)
  }

  goHome() {
    this.router.navigate(['/home']).then(r => r);
  }

  goAirports() {
    this.router.navigate(['/airports']).then(r => r);
  }

  GoVoyages() {
    this.router.navigate(['/voyages']).then(r => r);
  }
}
