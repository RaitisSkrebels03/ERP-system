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
import {Router} from '@angular/router';
import { ActivatedRoute } from '@angular/router';
import {MatTableModule} from '@angular/material/table';

@Component({
  selector: 'app-manufacturing-order-details',
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
    MatTableModule],
  templateUrl: './manufacturing-order-details.component.html',
  styleUrl: './manufacturing-order-details.component.css'
})
export class ManufacturingOrderDetailsComponent {
  id: number;
  client = new Client('https://localhost:44340');
  order: ManufacturingOrderDto = new ManufacturingOrderDto();
  project: ProjectDto;
  product: ProductDto;
  bill: BillOfMaterialDto;
  dateStart;
  dateEnd;
 
  constructor(private _router: Router, private _route: ActivatedRoute) {}

  ngOnInit() {
    this._route.params.subscribe(params => {
    this.id = params['id'];
    });
    this.fetchData();
  }

  async fetchData() {
    try {
      this.order = await this.client.manufacturingOrdersGET(this.id);
      this.project = await this.client.projectsGET(this.order.fk_project);
      this.product = await this.client.productsGET(this.order.fk_product);
      this.bill = await this.client.billsOfMaterialsGET(this.order.fk_bom);
      this.dateStart = this.convertUnixTimeToDate(this.order.date_start_planned);
      this.dateEnd = this.convertUnixTimeToDate(this.order.date_end_planned);
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

  update(){
    this._router.navigate(['/mrp/orders/update', this.id]);
  }

}
