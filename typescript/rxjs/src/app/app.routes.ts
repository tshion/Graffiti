import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'home',
    loadComponent: () => import('./home/home.page').then((m) => m.HomePage),
  },
  {
    path: 'scene1',
    loadComponent: () => import('./scene1/scene1.page').then((m) => m.Scene1Page),
  },
  {
    path: 'scene2',
    loadComponent: () => import('./scene2/scene2.page').then((m) => m.Scene2Page),
  },
  {
    path: '',
    redirectTo: 'home',
    pathMatch: 'full',
  },
];
