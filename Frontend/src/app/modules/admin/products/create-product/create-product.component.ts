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
import { Client, ProductDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';


@Component({
  selector: 'app-create-product',
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
  templateUrl: './create-product.component.html',
  styleUrl: './create-product.component.scss'
})
export class CreateProductComponent {
  product: ProductDto = new ProductDto();

  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;

  constructor(private _router: Router){}

  async save(){

    this.product.width_units = this.product.length_units;
    this.product.width_units = this.product.height_units;

    try {
      await this.client.productsPOST(this.product);
      this._router.navigate(['/products']);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/products']);
  }
}
