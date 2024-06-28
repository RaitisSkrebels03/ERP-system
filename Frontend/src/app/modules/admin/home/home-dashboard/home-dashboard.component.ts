import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import {Router} from '@angular/router';
import { MatButtonModule } from '@angular/material/button';


@Component({
  selector: 'app-home-dashboard',
  standalone: true,
  imports: [CommonModule,
            MatIconModule,
            MatButtonModule],
  templateUrl: './home-dashboard.component.html',
  styleUrl: './home-dashboard.component.css'
})
export class HomeDashboardComponent {

  constructor(private _router: Router) {}

  openModule(moduleTitle: string){
    this._router.navigate(['/', moduleTitle]);
  }
}
