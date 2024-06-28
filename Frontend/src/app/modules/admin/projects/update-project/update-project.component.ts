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
import { EditorModule } from '@tinymce/tinymce-angular';
import { ActivatedRoute } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';

@Component({
  selector: 'app-update-project',
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
  templateUrl: './update-project.component.html',
  styleUrl: './update-project.component.scss'
})
export class UpdateProjectComponent {
  id: number;
  project: ProjectDto = new ProjectDto();
  errorAlert = false;
  dateStart;
  dateEnd;
  dateStartUnix;
  dateEndUnix;

  client = new Client('https://localhost:44340');

  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.fetchData();
  }

  async fetchData(){
    try {
      this.project = await this.client.projectsGET(this.id);
      this.dateStart = this.unixTimestampToHtmlDate(this.project.date_start);
      this.dateEnd = this.unixTimestampToHtmlDate(this.project.date_end);
      this.dateStartUnix = this.project.date_start;
      this.dateEndUnix = this.project.date_end;
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
      await this.client.projectsPUT(Number(this.id), this.project)
      this._router.navigate(['/projects']);
    } catch (error) {
      console.error(error)
      this.errorAlert = true
    }
  }

  cancel(){
    this._router.navigate(['/projects']);
  }

}
