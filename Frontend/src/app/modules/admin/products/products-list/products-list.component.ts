import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Client, ProductDto } from 'app/api-client/api-client';
import {Router} from '@angular/router'
import {MatButtonModule} from '@angular/material/button';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import {MatSort, Sort, MatSortModule} from '@angular/material/sort';
import {LiveAnnouncer} from '@angular/cdk/a11y';
import {MatIconModule} from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-products-list',
  standalone: true,
  imports: [CommonModule, 
    MatButtonModule, 
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatIconModule,
    MatInputModule],
  templateUrl: './products-list.component.html',
  styleUrl: './products-list.component.scss'
})
export class ProductsListComponent implements OnInit, AfterViewInit{
  client = new Client('https://localhost:44340');
  products: ProductDto[];
  public productsList = new MatTableDataSource<any>([]);

  @ViewChild(MatPaginator) private paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  constructor(private _router: Router, private _liveAnnouncer: LiveAnnouncer) {}

  ngOnInit() {
    this.fetchData();
  }

  ngAfterViewInit(): void {
    this.productsList.paginator = this.paginator;
    this.productsList.sort = this.sort;
  }

  async fetchData() {
    try {
      this.products = await this.client.productsAll();
      this.productsList.data = this.products;
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
    this.productsList.data = this.products.filter(a => a.label.toLowerCase().includes(value.toLowerCase()));
  }

  createNewProduct(){
    this._router.navigate(['/products/create']);
  }

  openProductDetails(id: number){
    this._router.navigate(['/products/details', id]);
  }

  updateProduct(id: number){
    this._router.navigate(['/products/update', id]);
  }

  async deleteProduct(id: number){
    try {
      await this.client.productsDELETE(id);
      window.location.reload();
    } catch (error) {
      console.error(error);
    }
  }

  createNewCategory(){
    this._router.navigate(['/products/createCategory']);
  } 

}
