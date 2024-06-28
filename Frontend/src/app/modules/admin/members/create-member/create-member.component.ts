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
import { Client, CountryDto, MemberDto, MembersTypeDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-member',
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
  providers: [NgModule],
  templateUrl: './create-member.component.html',
  styleUrl: './create-member.component.css'
})
export class CreateMemberComponent {
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  member: MemberDto = new MemberDto();
  id: number;
  memberTypes: MembersTypeDto[];
  countries: CountryDto[];

  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit(){
    this._route.params.subscribe(params => {
      this.id = params['id'];
      });
    this.fetchData();
  }

  async fetchData(){
    this.memberTypes = await this.client.membersTypesAll();
    this.countries = await this.client.countriesAll();
  }

  async save(){
    this.member.typeid = "2"; 
    try {
      await this.client.membersPOST(this.member);
      this._router.navigate(['/members']);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/members']);
  }

  isPhysicalPerson(): boolean {
    return this.member.morphy === 'phy';
  }

  isCompany(): boolean {
    return this.member.morphy === 'mor';
  }
}
