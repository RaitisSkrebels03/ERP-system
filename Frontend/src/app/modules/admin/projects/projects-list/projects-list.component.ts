import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Client, ProjectDto } from 'app/api-client/api-client';
import {Router} from '@angular/router'
import {MatButtonModule} from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon'
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';


@Component({
  selector: 'app-projects-list',
  standalone: true,
  imports: [CommonModule, 
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatFormFieldModule,
    MatInputModule],
  templateUrl: './projects-list.component.html',
  styleUrl: './projects-list.component.css'
})
export class ProjectsListComponent implements OnInit, AfterViewInit{
  client = new Client('https://localhost:44340');
  projects: ProjectDto[];
  filteredProjects: ProjectDto[];
  public projectsList = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _router: Router, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.projectsList.paginator = this.paginator;
    this.projectsList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.projects = await this.client.projectsAll();
      this.projectsList.data = this.projects;
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
    this.projectsList.data = this.projects.filter(a => a.title.toLowerCase().includes(value.toLowerCase()));
  }

  createNewProject(){
    this._router.navigate(['/projects/create']);
  }

  openProjectDetails(id: number){
    this._router.navigate(['/projects/details', id]);
  }

  updateProject(id: number){
    this._router.navigate(['/projects/update', id]);
  }

  createNewTask(id: number){
    this._router.navigate(['/projects/createTask', id]);
  }

  openTasksList(id: number){
    this._router.navigate(['/projects/tasks', id]);
  }

  async deleteProject(id: number){
    try {
      await this.client.projectsDELETE(id)
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }
}
