import { Routes } from '@angular/router';
import { BillsOfMaterialsListComponent } from './bills-of-materials-list/bills-of-materials-list.component';
import { CreateBillsOfMaterialsComponent } from './create-bills-of-materials/create-bills-of-materials.component';
import { BillOfMaterialsDetailsComponent } from './bill-of-materials-details/bill-of-materials-details.component';
import { UpdateBillsOfMaterialsComponent } from './update-bills-of-materials/update-bills-of-materials.component';
import { ManufacturingOrdersListComponent } from './manufacturing-orders-list/manufacturing-orders-list.component';
import { ManufacturingOrderDetailsComponent } from './manufacturing-order-details/manufacturing-order-details.component';
import { CreateManufacturingOrderComponent } from './create-manufacturing-order/create-manufacturing-order.component';
import { UpdateManufacturingOrderComponent } from './update-manufacturing-order/update-manufacturing-order.component';

export default [
    {
        path     : 'bills',
        component: BillsOfMaterialsListComponent,
    },
    {
        path     : 'bills/details/:id',
        component: BillOfMaterialsDetailsComponent,
    },
    {
        path     : 'bills/create',
        component: CreateBillsOfMaterialsComponent,
    },
    {
        path     : 'bills/update/:id',
        component: UpdateBillsOfMaterialsComponent,
    },
    {
        path     : 'orders',
        component: ManufacturingOrdersListComponent,
    },
    {
        path     : 'orders/details/:id',
        component: ManufacturingOrderDetailsComponent,
    },
    {
        path     : 'orders/create',
        component: CreateManufacturingOrderComponent,
    },
    {
        path     : 'orders/update/:id',
        component: UpdateManufacturingOrderComponent,
    }
] as Routes;