import { Component} from '@angular/core';
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
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-thirdparty-details',
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
    FormsModule],
  templateUrl: './thirdparty-details.component.html',
  styleUrl: './thirdparty-details.component.css'
})
export class ThirdpartyDetailsComponent {
  client = new Client('https://localhost:44340');
  thirdParty: ThirdPartyDto = new ThirdPartyDto();
  countries: CountryDto[];
  id: number;

  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.fetchData();
  }


  async fetchData() {
    try {
      this.thirdParty = await this.client.thirdpartiesGET(this.id);
      this.countries = await this.client.countriesAll();
    } catch (error) {
      console.error(error);
    }
  }

  update(){
    this._router.navigate(['/thirdparties/update', this.id]);
  }
}
