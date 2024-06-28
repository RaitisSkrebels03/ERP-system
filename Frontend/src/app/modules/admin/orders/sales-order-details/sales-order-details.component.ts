import { Component} from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDividerModule } from '@angular/material/divider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Client, OrderDto, ProjectDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-sales-order-details',
  standalone: true,
  imports: [CommonModule,
    MatInputModule,
    MatSelectModule,
    MatFormFieldModule,
    MatDividerModule,
    MatCheckboxModule,
    MatRadioModule,
    MatButtonModule,
    MatIconModule,
    FormsModule],
  templateUrl: './sales-order-details.component.html',
  styleUrl: './sales-order-details.component.css'
})
export class SalesOrderDetailsComponent {
  client = new Client('https://localhost:44340');
  order: OrderDto = new OrderDto();
  projects: ProjectDto[];
  id: number;
  date;
  deliveryDate;

  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.fetchData();
  }

  async fetchData() {
    try {
      this.order = await this.client.ordersGET(this.id);
      this.date = this.unixTimestampToHtmlDate(this.order.date);
      this.deliveryDate = this.convertUnixTimeToDate(this.order.delivery_date);
      this.projects = await this.client.projectsAll();
    } catch (error) {
      console.error(error);
    }
  }

  update(){
    this._router.navigate(['/orders/sales/update', this.id]);
  }

  unixTimestampToHtmlDate(unixTimestamp: number): string{
    const milliseconds = unixTimestamp * 1000;
    const date = new Date(milliseconds);
    const formattedDate = date.toISOString().split('T')[0];
    return formattedDate;
  }

  convertUnixTimeToDate(unixTimestamp: number){
    const date = new Date(unixTimestamp * 1000);
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    return `${year}-${month}-${day}T${hours}:${minutes}`;
  }
  
}
