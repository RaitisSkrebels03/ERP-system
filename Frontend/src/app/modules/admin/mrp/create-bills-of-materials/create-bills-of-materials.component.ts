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
import { BillOfMaterialDto, Client, ProductDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-create-bills-of-materials',
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
  templateUrl: './create-bills-of-materials.component.html',
  styleUrl: './create-bills-of-materials.component.scss'
})
export class CreateBillsOfMaterialsComponent {
  bill: BillOfMaterialDto = new BillOfMaterialDto();
  products: ProductDto[]
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  hours: number;
  minutes: number;

  constructor(private _router: Router){}

  ngOnInit(){
    this.fetchData();
  }

  async fetchData(){
    try{
      this.products = await this.client.productsAll();
    } catch(error){
      console.error(error);
    }
  }

  async save(){
    this.bill.duration = String(3600*this.hours + 60*this.minutes);
    //this.bill.total_cost = Number(this.products.at(this.bill.fk_product).price)*this.bill.qty;
    try {
      await this.client.billsOfMaterialsPOST(this.bill)
      this._router.navigate(['/mrp/bills']);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/mrp/bills']);
  }
}
