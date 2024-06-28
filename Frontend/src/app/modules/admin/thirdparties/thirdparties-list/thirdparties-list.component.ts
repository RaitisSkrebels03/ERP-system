import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Client, ThirdPartyDto } from 'app/api-client/api-client';
import {Router} from '@angular/router'
import {MatButtonModule} from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-thirdparties-list',
  standalone: true,
  imports: [CommonModule, 
    MatButtonModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatInputModule],
  templateUrl: './thirdparties-list.component.html',
  styleUrl: './thirdparties-list.component.scss'
})
export class ThirdpartiesListComponent implements OnInit, AfterViewInit{
  client = new Client('https://localhost:44340');
  thirdparties: ThirdPartyDto[];
  public thirdpartiesList = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  ;
  constructor(private _router: Router, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.thirdpartiesList.paginator = this.paginator;
    this.thirdpartiesList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.thirdparties = await this.client.thirdpartiesAll();
      this.thirdpartiesList.data = this.thirdparties;
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
    this.thirdpartiesList.data = this.thirdparties.filter(a => a.name.toLowerCase().includes(value.toLowerCase()));
  }

  createNewThirdParty(){
    this._router.navigate(['/thirdparties/create']);
  }

  openThirdPartyDetails(id: number){
    this._router.navigate(['/thirdparties/details', id]);
  }

  updateThirdParty(id: number){
    this._router.navigate(['/thirdparties/update', id]);
  }

  async deleteThirdParty(id: number){
    try {
      await this.client.thirdpartiesDELETE(id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }
}
