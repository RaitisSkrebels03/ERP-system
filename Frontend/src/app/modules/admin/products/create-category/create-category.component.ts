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
import { Client, CategoryDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';
import { ColorPickerService, ColorPickerModule  } from 'ngx-color-picker';

@Component({
  selector: 'app-create-category',
  standalone: true,
  imports: [CommonModule,
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
    EditorModule,
    ColorPickerModule],
  templateUrl: './create-category.component.html',
  styleUrl: './create-category.component.scss'
})
export class CreateCategoryComponent {
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  category: CategoryDto = new CategoryDto();
  color: string = '#000000';

  ref: string;
  label: string;
  description: string;

  constructor(private _router: Router, private colorPickerService: ColorPickerService){}

  onColorChange(color: string): void {
    this.color = color;
  }


  async save(){

    this.category = {
      ref: this.ref,
      label: this.label,
      description: this.description,
      type: "0",
      color: this.color.slice(1)
    } as CategoryDto;

    try {
      await this.client.categoriesPOST(this.category);
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
