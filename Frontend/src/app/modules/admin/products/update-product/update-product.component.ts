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
import {EditorModule} from '@tinymce/tinymce-angular';
import { ActivatedRoute } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';


@Component({
  selector: 'app-update-product',
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
  templateUrl: './update-product.component.html',
  styleUrl: './update-product.component.scss'
})
export class UpdateProductComponent {
  id: number;
  product: ProductDto = new ProductDto();

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
      this.product = await this.client.productsGET(this.id);
      this.product.price = this.product.price.slice(0, -9);
    } catch (error) {
      console.error(error);
    }
  }

  async save(){

    try {
      await this.client.productsPUT(this.id, this.product);
      this._router.navigate(['/products']);
    } catch (error) {
      console.error(error);
      this.errorAlert = true;
    }
  }

  cancel(){
    this._router.navigate(['/products']);
  }
}
