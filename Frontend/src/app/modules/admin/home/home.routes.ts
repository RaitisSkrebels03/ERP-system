import { Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { HomeDashboardComponent } from './home-dashboard/home-dashboard.component';

export default [
    {
        path     : 'aboutus',
        component: HomeComponent,
    },
    {
        path     : '',
        component: HomeDashboardComponent,
    },
] as Routes;