import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDividerModule } from '@angular/material/divider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { Client, MembersTypeDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-create-members-type',
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
    FormsModule,
    RouterLink,
    FuseAlertComponent,
    EditorModule],
  templateUrl: './create-members-type.component.html',
  styleUrl: './create-members-type.component.scss'
})
export class CreateMembersTypeComponent {
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  membertype: MembersTypeDto = new MembersTypeDto();
  id: number;

  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit(){
    this._route.params.subscribe(params => {
      this.id = params['id'];
      });
  }

  async save(){
    try {
      await this.client.membersTypesPOST(this.membertype);
      this._router.navigate(['/members/types']);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/members/types']);
  }
}
