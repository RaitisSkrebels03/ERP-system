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
import { Client, ProjectDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';


@Component({
  selector: 'app-create-project',
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
  templateUrl: './create-project.component.html',
  styleUrl: './create-project.component.scss'
})

export class CreateProjectComponent {
  project: ProjectDto = new ProjectDto();
  dateStart: Date;
  dateEnd: Date;
  dateStartUnix;
  dateEndUnix;

  client = new Client('https://localhost:44340');
  errorAlert: boolean = false;


  constructor(private _router: Router) {}

  onStartDateChange() {
    const selectedDate = new Date(this.dateStart);
    const unixTimeMilliseconds = selectedDate.getTime();
    this.dateStartUnix = Math.floor(unixTimeMilliseconds / 1000);
  }

  onEndDateChange(){
    const selectedDate = new Date(this.dateEnd);
    const unixTimeMilliseconds = selectedDate.getTime();
    this.dateEndUnix = Math.floor(unixTimeMilliseconds / 1000);
  }

  async save(){

    this.project.date_start = this.dateStartUnix;
    this.project.date_end = this.dateEndUnix;
    
    try {
      await this.client.projectsPOST(this.project);
      this._router.navigate(['/projects']);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/projects']);
  }
}
