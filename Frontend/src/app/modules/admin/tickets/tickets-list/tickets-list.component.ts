import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Client, TicketDto } from 'app/api-client/api-client';
import {Router} from '@angular/router'
import {MatButtonModule} from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-tickets-list',
  standalone: true,
  imports: [CommonModule, 
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatInputModule],
  templateUrl: './tickets-list.component.html',
  styleUrl: './tickets-list.component.scss'
})
export class TicketsListComponent {
  client = new Client('https://localhost:44340');
  tickets: TicketDto[];
  public ticketsList = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  
  constructor(private _router: Router, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.ticketsList.paginator = this.paginator;
    this.ticketsList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.tickets = await this.client.ticketsAll();
      this.ticketsList.data = this.tickets;
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
    this.ticketsList.data = this.tickets.filter(a => a.ref.toLowerCase().includes(value.toLowerCase()));
  }

  unixTimestampToHtmlDate(unixTimestamp: number): string{
    const milliseconds = unixTimestamp * 1000;
    const date = new Date(milliseconds);
    const formattedDate = date.toISOString().split('T')[0];
    return formattedDate;
  }

  createNewTicket(){
    this._router.navigate(['/tickets/create']);
  }

  openTicketDetails(id: number){
    this._router.navigate(['/tickets/details', id]);
  }

  updateTicket(id: number){
    this._router.navigate(['/tickets/update', id]);
  }

  async deleteTicket(id: number){
    try {
      await this.client.ticketsDELETE(id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }
}
