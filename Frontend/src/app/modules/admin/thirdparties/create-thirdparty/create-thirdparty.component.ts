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
import { Client, CountryDto, ThirdPartyDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-create-thirdparty',
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
    EditorModule],
  templateUrl: './create-thirdparty.component.html',
  styleUrl: './create-thirdparty.component.scss'
})
export class CreateThirdpartyComponent {
  
  thirdParty: ThirdPartyDto = new ThirdPartyDto();
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  countries: CountryDto[];

  constructor(private _router: Router) {}

  ngOnInit(){
    this.fetchData();
  }

  async fetchData(){
    try{
      this.countries = await this.client.countriesAll();
    }catch(error){
      console.error(error);
    }
  }

  async save(){

    try {
      await this.client.thirdpartiesPOST(this.thirdParty);
      this._router.navigate(['/thirdparties']);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/thirdparties']);
  }

}
