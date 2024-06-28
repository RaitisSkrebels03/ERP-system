import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Client, MembersTypeDto } from 'app/api-client/api-client';
import {Router} from '@angular/router'
import {MatButtonModule} from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-members-types-list',
  standalone: true,
  imports: [CommonModule, 
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatInputModule],
  templateUrl: './members-types-list.component.html',
  styleUrl: './members-types-list.component.scss'
})
export class MembersTypesListComponent {
  client = new Client('https://localhost:44340');
  memberTypes: MembersTypeDto[];
  public membersTypeList = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _router: Router, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.membersTypeList.paginator = this.paginator;
    this.membersTypeList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.memberTypes = await this.client.membersTypesAll();
      this.membersTypeList.data = this.memberTypes;
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
    this.membersTypeList.data = this.memberTypes.filter(a => a.label.toLowerCase().includes(value.toLowerCase()));
  }

  async deleteMemberType(id: number){
    try {
      await this.client.membersTypesDELETE(id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }

  createNewMemberType(){
    this._router.navigate(['/members/type/create']);
  }

  updateMemberType(id: number){
    this._router.navigate(['/members/type/update', id])
  }

  openMemberTypeDetails(id: number){
    this._router.navigate(['/members/type/details', id]);
  }
}
