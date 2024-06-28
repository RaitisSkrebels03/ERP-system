import { Routes } from '@angular/router';
import { SalesOrdersListComponent } from './sales-orders-list/sales-orders-list.component';
import { CreateSalesOrderComponent } from './create-sales-order/create-sales-order.component';
import { UpdateSalesOrderComponent } from './update-sales-order/update-sales-order.component';
import { SalesOrderDetailsComponent } from './sales-order-details/sales-order-details.component';
export default [
    {
        path     : 'sales',
        component: SalesOrdersListComponent,
    },
    {
        path     : 'sales/details/:id',
        component: SalesOrderDetailsComponent,
    },
    {
        path     : 'sales/create',
        component: CreateSalesOrderComponent,
    },
    {
        path     : 'sales/update/:id',
        component: UpdateSalesOrderComponent,
    },

] as Routes;