import { Component } from '@angular/core';
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
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-create-sales-order',
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
    FormsModule,
    RouterLink,
    FuseAlertComponent,
    EditorModule],
  templateUrl: './create-sales-order.component.html',
  styleUrl: './create-sales-order.component.scss'
})
export class CreateSalesOrderComponent {
  order: OrderDto = new OrderDto();
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  projects: ProjectDto[];
  date: Date;
  deliveryDate: Date;
  dateUnix;
  deliveryDateUnix;

  constructor(private _router: Router){}

  ngOnInit(){
    this.fetchData();
  }
  
  async fetchData(){
    try {
      this.projects = await this.client.projectsAll();
    } catch (error) {
      console.error(error);
    }
  }

  async save(){
    this.order.date = this.dateUnix;
    this.order.delivery_date = this.deliveryDateUnix;
    this.order.ref_client = this.order.ref_customer;
    try {
      await this.client.ordersPOST(this.order)
      this._router.navigate(['/orders/sales']);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/orders/sales']);
  }

  onDateChange() {
    const selectedDate = new Date(this.date);
    const unixTimeMilliseconds = selectedDate.getTime();
    this.dateUnix = Math.floor(unixTimeMilliseconds / 1000);
  }

  onDeliveryDateChange(){
    const selectedDate = new Date(this.deliveryDate);
    const unixTimeMilliseconds = selectedDate.getTime();
    this.deliveryDateUnix = Math.floor(unixTimeMilliseconds / 1000);
  }
}
