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
import { Client, UserDto, ProjectDto, TicketDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import { EditorModule } from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-update-ticket',
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
    FuseAlertComponent,
    EditorModule],
  templateUrl: './update-ticket.component.html',
  styleUrl: './update-ticket.component.scss'
})
export class UpdateTicketComponent {
  id: number;
  ticket: TicketDto = new TicketDto();
  projects: ProjectDto[];
  users: UserDto[];
  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;
  projectId: number;

  constructor(private _router: Router, private _route: ActivatedRoute){}

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.fetchData();
  }

  async fetchData(){
    try {
      this.ticket = await this.client.ticketsGET(this.id);
      this.projectId = Number(this.ticket.fk_project);
      this.projects = await this.client.projectsAll();
      this.users = await this.client.usersAll();
    } catch (error) {
      console.error(error);
    }
  }

  async save(){
    this.ticket.fk_project = String(this.projectId);
    try {
      await this.client.ticketsPUT(this.id, this.ticket);
      this._router.navigate(['/tickets']);
    } catch (error) {
      console.error(error);
      this.errorAlert = true;
    }
  }

  cancel(){
    this._router.navigate(['/tickets']);
  }
}
