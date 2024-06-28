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
import { Client, MembersTypeDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-member-type-details',
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
  templateUrl: './member-type-details.component.html',
  styleUrl: './member-type-details.component.css'
})
export class MemberTypeDetailsComponent {
  client = new Client('https://localhost:44340');
  memberType: MembersTypeDto = new MembersTypeDto();
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
      this.memberType = await this.client.membersTypesGET(this.id);
    } catch (error) {
      console.error(error);
    }
  }

  update(){
    this._router.navigate(['/members/type/update', this.id]);
  }

}
