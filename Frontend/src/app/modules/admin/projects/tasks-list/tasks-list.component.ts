import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { Client, TaskDto } from 'app/api-client/api-client';
import {Router} from '@angular/router';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import { ActivatedRoute } from '@angular/router';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import { MatInputModule } from '@angular/material/input';


@Component({
  selector: 'app-tasks-list',
  standalone: true,
  imports: [CommonModule,
    MatButtonModule,
    MatIconModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatInputModule],
  templateUrl: './tasks-list.component.html',
  styleUrl: './tasks-list.component.scss'
})
export class TasksListComponent implements OnInit, AfterViewInit{
  client = new Client('https://localhost:44340');
  tasks: TaskDto[];
  public tasksList = new MatTableDataSource<any>([]);
  id: number;

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _router: Router, private _route: ActivatedRoute, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.id = params['id'];
      });
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.tasksList.paginator = this.paginator;
    this.tasksList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.tasks = (await this.client.tasksAll()).filter(a => a.fk_project == String(this.id));
      this.tasksList.data = this.tasks
    } catch (error) {
      console.error(error);
    }
  }

  announceSortChange(sortState: Sort) {
    if (sortState.direction) {
      this._liveAnnouncer.announce(`Sorted ${sortState.direction}ending`);
    } else {
      this._liveAnnouncer.announce('Sorting cleared');
    }
  }

  public doFilter = (value: string) => {
    this.tasksList.data = this.tasks.filter(a => a.label.toLowerCase().includes(value.toLowerCase()));
  }

  createNewTask(){
    this._router.navigate(['/projects/createTask', this.id]);
  }

  openTaskDetails(id: number){
    this._router.navigate(['/projects/task', id]);
  }

  updateTask(id: number){
    this._router.navigate(['/projects/task/update', id]);
  }

  async deleteTask(id: number){
    try {
      await this.client.tasksDELETE(id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }
}
