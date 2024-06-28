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
import { Client, ProjectDto, TaskDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import {MatTableModule} from '@angular/material/table';

@Component({
  selector: 'app-project-details',
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
    MatTableModule],
  templateUrl: './project-details.component.html',
  styleUrl: './project-details.component.css'
})
export class ProjectDetailsComponent{
  id: number;
  client = new Client('https://localhost:44340');
  project: ProjectDto = new ProjectDto();
  tasksList: TaskDto[]
  dateStart;
  dateEnd;
  dateStartUnix;
  dateEndUnix;
  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit() {
    this._route.params.subscribe(params => {
    this.id = params['id'];
    });
    this.fetchData();
  }

  async fetchData() {
    try {
      this.project = await this.client.projectsGET(this.id);
      this.tasksList = (await this.client.tasksAll()).filter(task => task.fk_project === String(this.id));
      this.dateStart = this.unixTimestampToHtmlDate(this.project.date_start);
      this.dateEnd = this.unixTimestampToHtmlDate(this.project.date_end);
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

  update(){
    this._router.navigate(['/projects/update', this.id]);
  }

  openTaskDetails(id: number){
    this._router.navigate(['/projects/task/details', id]);
  }

  updateTask(id: number){
    this._router.navigate(['/projects/task/update', id]);
  }

  async deleteTask(id: number){
    try {
      await this.client.tasksDELETE(id);
    } catch (error) {
      console.error(error);
    }
  }
}
