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
import { BillOfMaterialDto, Client, ManufacturingOrderDto, ProductDto, ProjectDto} from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-create-manufacturing-order',
  standalone: true,
  imports: [CommonModule,
    CommonModule,
    CommonModule,
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
  templateUrl: './create-manufacturing-order.component.html',
  styleUrl: './create-manufacturing-order.component.scss'
})
export class CreateManufacturingOrderComponent {
  order: ManufacturingOrderDto = new ManufacturingOrderDto();
  products: ProductDto[];
  bills: BillOfMaterialDto[];
  projects: ProjectDto[];
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  dateStart: Date;
  dateEnd: Date;
  dateStartUnix;
  dateEndUnix;

  constructor(private _router: Router) {}

  ngOnInit(){
    this.fetchData();
  }

  async fetchData(){
    try{
      this.products = await this.client.productsAll();
      this.bills = await this.client.billsOfMaterialsAll();
      this.projects = await this.client.projectsAll();
    }catch(error){
      console.error(error);
    }
  }

  onStartDateChange() {
    const selectedDate = new Date(this.dateStart);
    const unixTimeMilliseconds = selectedDate.getTime();
    this.dateStartUnix = Math.floor(unixTimeMilliseconds / 1000);
  }

  onEndDateChange(){
    const selectedDate = new Date(this.dateEnd);
    const unixTimeMilliseconds = selectedDate.getTime();
    this.dateEndUnix = Math.floor(unixTimeMilliseconds / 1000);
  }

  async save(){ 
    this.order.date_start_planned = this.dateStartUnix;
    this.order.date_end_planned = this.dateEndUnix;  
    try {
      await this.client.manufacturingOrdersPOST(this.order);
      this._router.navigate(['/mrp/orders']);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/mrp/orders']);
  }
}
