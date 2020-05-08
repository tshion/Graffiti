import { Component } from '@angular/core';

import { HomePage } from '../pages/home/home';

@Component({
  template: `<ion-nav [root]="rootPage"></ion-nav>`
})
export class MyApp {
  rootPage: any = HomePage;
}
