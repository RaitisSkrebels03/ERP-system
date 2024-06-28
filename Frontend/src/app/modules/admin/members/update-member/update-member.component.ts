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
import { Router, RouterLink } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';

@Component({
  selector: 'app-update-member',
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
  templateUrl: './update-member.component.html',
  styleUrl: './update-member.component.scss'
})
export class UpdateMemberComponent {
  id: number;
  member: MemberDto = new MemberDto();
  memberTypes: MembersTypeDto[];
  countries: CountryDto[];
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
      this.member = await this.client.membersGET(this.id);
      this.memberTypes = await this.client.membersTypesAll();
      this.countries = await this.client.countriesAll();
    } catch (error) {
      console.error(error);
    }
  }

  async save(){

    try {
      await this.client.membersPUT(this.id, this.member);
      this._router.navigate(['/members']);
    } catch (error) {
      console.error(error);
      this.errorAlert = true;
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
