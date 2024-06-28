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
import { Client, TaskDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-task-details',
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
  templateUrl: './task-details.component.html',
  styleUrl: './task-details.component.css'
})
export class TaskDetailsComponent {
  id: number;
  client = new Client('https://localhost:44340');
  task: TaskDto = new TaskDto();
  dateStart;
  dateEnd;
  hours: number;
  minutes: number;

  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit() {
    this._route.params.subscribe(params => {
    this.id = params['id'];
    });
    this.fetchData();
  }

  async fetchData() {
    try {
      this.task = await this.client.tasksGET(this.id);
      this.hours = Math.floor(Number(this.task.planned_workload) / 3600);
      this.minutes = (Number(this.task.planned_workload) - this.hours*3600) / 60;
      this.dateStart = this.convertUnixTimeToDate(this.task.date_start);
      this.dateEnd = this.convertUnixTimeToDate(this.task.date_end);
    } catch (error) {
      console.error(error);
    }
  }

  convertUnixTimeToDate(unixTime){
    const date = new Date(unixTime * 1000);
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    return `${year}-${month}-${day}T${hours}:${minutes}`;
  }

  update(){
    this._router.navigate(['/projects/task/update', this.id]);
  }
  
}
