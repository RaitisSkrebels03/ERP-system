import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatDividerModule } from '@angular/material/divider';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatRadioModule } from '@angular/material/radio';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { BillOfMaterialDto, Client, ManufacturingOrderDto, ProductDto, ProjectDto } from 'app/api-client/api-client';
import { FormsModule } from '@angular/forms';
import { Router, RouterLink } from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import { FuseAlertComponent } from '@fuse/components/alert';

@Component({
  selector: 'app-update-manufacturing-order',
  standalone: true,
  imports: [CommonModule,
    MatInputModule,
    MatSelectModule,
    MatFormFieldModule,
    MatDividerModule,
    MatCheckboxModule,
    MatRadioModule,
    MatButtonModule,
    MatIconModule,
    FormsModule,
    RouterLink,
    FuseAlertComponent],
  templateUrl: './update-manufacturing-order.component.html',
  styleUrl: './update-manufacturing-order.component.scss'
})
export class UpdateManufacturingOrderComponent {
  id: number;
  order: ManufacturingOrderDto = new ManufacturingOrderDto();
  bills: BillOfMaterialDto[];
  products: ProductDto[];
  projects: ProjectDto[];
  errorAlert = false;
  dateStart;
  dateEnd;
  dateStartUnix;
  dateEndUnix;

  client = new Client('https://localhost:44340');

  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit() {
    this._route.params.subscribe(params => {
      this.id = params['id'];
    });
    this.fetchData();
  }

  async fetchData(){
    try {
      this.order = await this.client.manufacturingOrdersGET(this.id);
      this.dateStart = this.convertUnixTimeToDate(this.order.date_start_planned);
      this.dateEnd = this.convertUnixTimeToDate(this.order.date_end_planned);
      this.dateStartUnix = this.order.date_start_planned;
      this.dateEndUnix = this.order.date_end_planned;
      this.bills = await this.client.billsOfMaterialsAll();
      this.products = await this.client.productsAll();
      this.projects = await this.client.projectsAll();
    } catch (error) {
      console.error(error);
    }
  }

  convertUnixTimeToDate(unixTime){
    const date = new Date(unixTime * 1000);
    const year = date.getFullYear();
    const month = String(date.getMonth() + 1).padStart(2, '0');
    const day = String(date.getDate()).padStart(2, '0');
    const hours = String(date.getHours()).padStart(2, '0');
    const minutes = String(date.getMinutes()).padStart(2, '0');
    return `${year}-${month}-${day}T${hours}:${minutes}`;
  }

  onStartDateChange() {
    const selectedDate = new Date(this.dateStart);
    const unixTimeMilliseconds = selectedDate.getTime();
    this.dateStartUnix = Math.floor(unixTimeMilliseconds / 1000);
  }

  onEndDateChange(){
    const selectedDate = new Date(this.dateEnd);
    const unixTimeMilliseconds = selectedDate.getTime();
    this.dateEndUnix = Math.floor(unixTimeMilliseconds / 1000);
  }

  async save(){
    this.order.date_start_planned = this.dateStartUnix;
    this.order.date_end_planned = this.dateEndUnix;
    try {
      await this.client.manufacturingOrdersPUT(this.id, this.order);
      this._router.navigate(['/mrp/orders']);
    } catch (error) {
      console.error(error)
      this.errorAlert = true;
    }
  }

  cancel(){
    this._router.navigate(['/mrp/orders']);
  }
}
