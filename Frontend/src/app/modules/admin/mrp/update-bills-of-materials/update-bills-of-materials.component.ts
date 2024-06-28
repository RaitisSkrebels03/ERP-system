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
import { ActivatedRoute } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import { EditorModule } from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-update-bills-of-materials',
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
  templateUrl: './update-bills-of-materials.component.html',
  styleUrl: './update-bills-of-materials.component.scss'
})
export class UpdateBillsOfMaterialsComponent {
  id: number;
  bill: BillOfMaterialDto = new BillOfMaterialDto();
  products: ProductDto[];
  hours: number;
  minutes: number;
  duration: string;
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
      this.bill = await this.client.billsOfMaterialsGET(this.id);
      this.products = await this.client.productsAll();
      this.duration = this.bill.duration.slice(0, -9);
      this.hours = Math.floor(Number(this.duration) / 3600);
      this.minutes = (Number(this.duration) - this.hours*3600) / 60;
    } catch (error) {
      console.error(error);
    }
  }

  async save(){
    this.bill.duration = String(3600*this.hours + 60*this.minutes);
    try {
      await this.client.billsOfMaterialsPUT(this.id, this.bill);
      this._router.navigate(['/mrp/bills']);
    } catch (error) {
      console.error(error);
      this.errorAlert = true;
    }
  }

  cancel(){
    this._router.navigate(['/mrp/bills']);
  }
}
