import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BillOfMaterialDto, Client, OrderDto } from 'app/api-client/api-client';
import { Router } from '@angular/router'
import { MatButtonModule } from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-bills-of-materials-list',
  standalone: true,
  imports: [CommonModule, 
    MatButtonModule, 
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatInputModule],
  templateUrl: './bills-of-materials-list.component.html',
  styleUrl: './bills-of-materials-list.component.scss'
})
export class BillsOfMaterialsListComponent {
  client = new Client('https://localhost:44340');
  bills: BillOfMaterialDto[];
  public billsList = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _router: Router, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.billsList.paginator = this.paginator;
    this.billsList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.bills = await this.client.billsOfMaterialsAll();
      this.billsList.data = this.bills;
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
    this.billsList.data = this.bills.filter(a => a.label.toLowerCase().includes(value.toLowerCase()));
  }

  createNewBill(){
    this._router.navigate(['/mrp/bills/create']);
  }

  openBillDetails(id: string){
    this._router.navigate(['/mrp/bills/details', id]);
  }

  updateBill(id: number){
    this._router.navigate(['/mrp/bills/update', id]);
  }

  async deleteBill(id: number){
    try {
      await this.client.billsOfMaterialsDELETE(id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }
}
