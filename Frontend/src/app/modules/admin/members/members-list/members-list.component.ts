import { Component, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Client, MemberDto } from 'app/api-client/api-client';
import {Router} from '@angular/router'
import {MatButtonModule} from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-members-list',
  standalone: true,
  imports: [CommonModule, 
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatInputModule],
  templateUrl: './members-list.component.html',
  styleUrl: './members-list.component.scss'
})
export class MembersListComponent {
  client = new Client('https://localhost:44340');
  members: MemberDto[];
  public membersList = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _router: Router, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.membersList.paginator = this.paginator;
    this.membersList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.members = await this.client.membersAll();
      this.membersList.data = this.members;
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
    this.membersList.data = this.members.filter(a => a.lastname.toLowerCase().includes(value.toLowerCase()));
  }

  async deleteMember(id: number){
    try {
      await this.client.membersDELETE(id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }

  createNewMember(){
    this._router.navigate(['/members/create']);
  }

  updateMember(id: number){
    this._router.navigate(['/members/update', id]);
  }

  openMemberDetails(id: number){
    this._router.navigate(['/members/details', id]);
  }

  createNewMembersType(){
    this._router.navigate(['/members/type/create']);
  }

  openMembersTypesList(){
    this._router.navigate(['/members/types']);
  }
}
