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
import { Router, RouterLink } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';
import { EditorModule } from '@tinymce/tinymce-angular';

@Component({
  selector: 'app-update-task',
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
  templateUrl: './update-task.component.html',
  styleUrl: './update-task.component.scss'
})
export class UpdateTaskComponent {
  id: number;
  task: TaskDto = new TaskDto();
  errorAlert = false;
  dateStart: string;
  dateEnd: string;
  dateStartUnix;
  dateEndUnix;
  hours: number;
  minutes: number;

  client = new Client('https://localhost:44340')

  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.fetchData();
  }

  async fetchData(){
    try {
      this.task = await this.client.tasksGET(this.id);
      this.hours = Math.floor(Number(this.task.planned_workload) / 3600);
      this.minutes = (Number(this.task.planned_workload) - this.hours*3600) / 60;
      this.dateStart = this.convertUnixTimeToDate(this.task.date_start);
      this.dateEnd = this.convertUnixTimeToDate(this.task.date_end);
      this.dateStartUnix = this.task.date_start;
      this.dateEndUnix = this.task.date_end;
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
    this.task.planned_workload = String(3600*this.hours + 60*this.minutes);
    this.task.date_start = this.dateStartUnix;
    this.task.date_end = this.dateEndUnix;
    try {
      await this.client.tasksPUT(this.id, this.task);
      this._router.navigate(['/projects/tasks', this.task.fk_project]);
    } catch (error) {
      console.error(error);
      this.errorAlert = true;
    }
  }

  cancel(){
    this._router.navigate(['/projects']);
  }
}
