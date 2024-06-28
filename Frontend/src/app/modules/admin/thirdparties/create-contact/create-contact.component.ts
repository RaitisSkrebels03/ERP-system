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
import { Client, ContactDto, CountryDto, ThirdPartyDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-create-contact',
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
  templateUrl: './create-contact.component.html',
  styleUrl: './create-contact.component.scss'
})
export class CreateContactComponent {
  contact: ContactDto = new ContactDto();
  thirdparties: ThirdPartyDto[];
  countries: CountryDto[];
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  dateOfBirth: Date;
  dateOfBirthUnix;

  constructor(private _router: Router) {}

  ngOnInit(){
    this.fetchData();
  }

  async fetchData(){
    try{
      this.thirdparties = await this.client.thirdpartiesAll();
      this.countries = await this.client.countriesAll();
    }catch(error){
      console.error(error);
    }
  }

  ondateOfBirthChange() {
    const selectedDate = new Date(this.dateOfBirth);
    const unixTimeMilliseconds = selectedDate.getTime();
    this.dateOfBirthUnix = Math.floor(unixTimeMilliseconds / 1000);
  }

  async save(){
    try {
      this.contact.birthday = String(this.dateOfBirth);
      await this.client.contactsPOST(this.contact);
      this._router.navigate(['/thirdparties/contacts']);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/thirdparties/contacts']);
  }

}
