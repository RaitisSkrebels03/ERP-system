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
import { ActivatedRoute } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import { EditorModule } from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-update-sales-order',
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
  templateUrl: './update-sales-order.component.html',
  styleUrl: './update-sales-order.component.scss'
})
export class UpdateSalesOrderComponent {
  id: number;
  order: OrderDto = new OrderDto();
  projects: ProjectDto[];
  date;
  deliveryDate;
  dateUnix;
  deliveryDateUnix;
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;

  constructor(private _router: Router, private _route: ActivatedRoute){}

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.fetchData();
  }

  async fetchData(){
    try {
      this.order = await this.client.ordersGET(this.id);
      this.date = this.unixTimestampToHtmlDate(this.order.date);
      this.deliveryDate = this.convertUnixTimeToDate(this.order.delivery_date);
      this.dateUnix = this.order.date;
      this.deliveryDateUnix = this.order.delivery_date;
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
      await this.client.ordersPUT(this.id, this.order);
      this._router.navigate(['/orders/sales']);
    } catch (error) {
      console.error(error);
      this.errorAlert = true;
    }
  }

  cancel(){
    this._router.navigate(['/orders/sales']);
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
