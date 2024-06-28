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
import { Client, ProjectDto, TicketDto, UserDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-create-ticket',
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
  templateUrl: './create-ticket.component.html',
  styleUrl: './create-ticket.component.scss'
})
export class CreateTicketComponent {
  ticket: TicketDto = new TicketDto();
  projects: ProjectDto[];
  users: UserDto[];
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  user: UserDto;
  projectId: number;


  constructor(private _router: Router) {}

  ngOnInit(){
    this.fetchData();
  }

  async fetchData(){
    try{
      this.projects = await this.client.projectsAll();
      this.users = await this.client.usersAll();
    }catch(error){
      console.error(error);
    }
  }

  async save(){
    this.ticket.fk_project = String(this.projectId);
    try {
      await this.client.ticketsPOST(this.ticket);
      this._router.navigate(['/tickets']);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/tickets']);
  }
}
