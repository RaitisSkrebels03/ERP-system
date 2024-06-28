import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Client, UserDto } from 'app/api-client/api-client';
import {Router} from '@angular/router'
import {MatButtonModule} from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon';

@Component({
  selector: 'app-users-list',
  standalone: true,
  imports: [CommonModule, 
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule],
  templateUrl: './users-list.component.html',
  styleUrl: './users-list.component.scss'
})
export class UsersListComponent {
  client = new Client('https://localhost:44340');
  users: UserDto[];
  public usersList = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _router: Router, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.usersList.paginator = this.paginator;
    this.usersList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.users = await this.client.usersAll();
      this.usersList.data = this.users;
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

  async deleteUser(id: number){
    try {
      await this.client.usersDELETE(id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }

  createNewUser(){
    this._router.navigate(['/users/create/']);
  }

  updateUser(id: number){
    this._router.navigate(['/users/update/', id]);
  }

  openUserDetails(id: number){
    this._router.navigate(['/users/details/', id]);
  }
}
