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
import { Client, ContactDto, CountryDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';

@Component({
  selector: 'app-update-contact',
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
    FuseAlertComponent],
  templateUrl: './update-contact.component.html',
  styleUrl: './update-contact.component.css'
})
export class UpdateContactComponent {
  id: number;
  contact: ContactDto = new ContactDto();
  countries: CountryDto[];
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  dateOfBirth;
  dateOfBirthUnix;

  constructor(private _router: Router, private _route: ActivatedRoute){}

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.fetchData();
  }

  async fetchData(){
    try {
      this.contact = await this.client.contactsGET(this.id);
      this.dateOfBirth = this.unixTimestampToHtmlDate(Number(this.contact.birthday));
      this.dateOfBirthUnix = Number(this.contact.birthday);
      this.countries = await this.client.countriesAll();
    } catch (error) {
      console.error(error);
    }
  }

  unixTimestampToHtmlDate(unixTimestamp: number): string{
    const milliseconds = unixTimestamp * 1000;
    const date = new Date(milliseconds);
    const formattedDate = date.toISOString().split('T')[0];
    return formattedDate;
  }

  ondateOfBirthChange() {
    const selectedDate = new Date(this.dateOfBirth);
    const unixTimeMilliseconds = selectedDate.getTime();
    this.dateOfBirthUnix = Math.floor(unixTimeMilliseconds / 1000);
  }

  async save(){
    try {
      this.contact.birthday = String(this.dateOfBirth);
      await this.client.contactsPUT(this.id, this.contact);
      this._router.navigate(['/thirdparties/contacts']);
    } catch (error) {
      console.error(error);
      this.errorAlert = true;
    }
  }

  cancel(){
    this._router.navigate(['/thirdparties/contacts']);
  }
}
