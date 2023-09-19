import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { IonicModule } from '@ionic/angular';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [
    IonicModule,
    RouterModule,
  ],
  templateUrl: 'home.page.html',
})
export class HomePage {
}
