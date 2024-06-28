import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Client, OrderDto } from 'app/api-client/api-client';
import { Router } from '@angular/router'
import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-sales-orders-list',
  standalone: true,
  imports: [CommonModule, 
    MatButtonModule, 
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatInputModule],
  templateUrl: './sales-orders-list.component.html',
  styleUrl: './sales-orders-list.component.scss'
})
export class SalesOrdersListComponent {
  client = new Client('https://localhost:44340');
  orders: OrderDto[];
  public ordersList = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _router: Router, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.ordersList.paginator = this.paginator;
    this.ordersList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.orders = await this.client.ordersAll();
      this.ordersList.data = this.orders;
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
    this.ordersList.data = this.orders.filter(a => a.ref.toLowerCase().includes(value.toLowerCase()));
  }

  unixTimestampToHtmlDate(unixTimestamp: number): string{
    const milliseconds = unixTimestamp * 1000;
    const date = new Date(milliseconds);
    const formattedDate = date.toISOString().split('T')[0];
    return formattedDate;
  }

  createNewOrder(){
    this._router.navigate(['/orders/sales/create']);
  }

  openOrderDetails(id: string){
    this._router.navigate(['/orders/sales/details', id]);
  }

  updateOrder(id: number){
    this._router.navigate(['/orders/sales/update', id]);
  }

  async deleteOrder(id: number){
    try {
      await this.client.ordersDELETE(id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }

}
