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
import { FuseAlertComponent } from '@fuse/components/alert';
import {EditorModule} from '@tinymce/tinymce-angular';
import { ActivatedRoute } from '@angular/router';


@Component({
  selector: 'app-create-task',
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
    MatIconModule,
    FormsModule,
    RouterLink,
    FuseAlertComponent,
    EditorModule],
  templateUrl: './create-task.component.html',
  styleUrl: './create-task.component.css'
})
export class CreateTaskComponent {
  client = new Client('https://localhost:44340')
  errorAlert: boolean = false;
  task: TaskDto = new TaskDto();
  id: number;
  dateStart: Date;
  dateEnd: Date;
  dateStartUnix;
  dateEndUnix;
  plannedWorkload: string;
  hours: number;
  minutes: number;


  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit(){
    this._route.params.subscribe(params => {
      this.id = params['id'];
      });
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
    this.task.fk_project = String(this.id);
    this.task.date_start = this.dateStartUnix;
    this.task.date_end = this.dateEndUnix;
    this.task.planned_workload = String(3600*this.hours + 60*this.minutes);

    try {
      await this.client.tasksPOST(this.task);
      this._router.navigate(['/projects/tasks', this.id]);
    } catch (error) {
      this.errorAlert = true;
      console.error(error);
    }
  }

  cancel(){
    this._router.navigate(['/projects']);
  }
}
