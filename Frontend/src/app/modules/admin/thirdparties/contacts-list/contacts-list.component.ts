import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Client, ContactDto, ThirdPartyDto } from 'app/api-client/api-client';
import {Router} from '@angular/router'
import {MatButtonModule} from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-contacts-list',
  standalone: true,
  imports: [CommonModule, 
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatInputModule],
  templateUrl: './contacts-list.component.html',
  styleUrl: './contacts-list.component.scss'
})
export class ContactsListComponent implements OnInit, AfterViewInit{
  client = new Client('https://localhost:44340');
  contacts: ContactDto[];
  public contactsList = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  ;
  constructor(private _router: Router, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.contactsList.paginator = this.paginator;
    this.contactsList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.contacts = await this.client.contactsAll();
      this.contactsList.data = this.contacts;
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
    this.contactsList.data = this.contacts.filter(a => a.lastname.toLowerCase().includes(value.toLowerCase()));
  }

  createNewContact(){
    this._router.navigate(['/thirdparties/contacts/create']);
  }

  openContactDetails(id: number){
    this._router.navigate(['/thirdparties/contacts/details', id]);
  }

  updateContact(id: number){
    this._router.navigate(['/thirdparties/contacts/update', id]);
  }

  async deleteContact(id: number){
    try {
      await this.client.contactsDELETE(id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }
}

