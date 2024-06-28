import { Route } from '@angular/router';
import { initialDataResolver } from 'app/app.resolvers';
import { LayoutComponent } from 'app/layout/layout.component';

// @formatter:off
/* eslint-disable max-len */
/* eslint-disable @typescript-eslint/explicit-function-return-type */
export const appRoutes: Route[] = [

    {
        path: '',
        component: LayoutComponent,
        resolve: {
            initialData: initialDataResolver
        },
        children: [
            {path: '', loadChildren: () => import('app/modules/admin/home/home.routes')},
            {path: 'products', loadChildren: () => import('app/modules/admin/products/products.routes')},
            {path: 'auth', loadChildren: () => import('app/modules/authorization/authorization.routes')},
            {path: 'projects', loadChildren: () => import('app/modules/admin/projects/projects.routes')},
            {path: 'thirdparties', loadChildren: () => import('app/modules/admin/thirdparties/thirdparties.routes')},
            {path: 'members', loadChildren: () => import('app/modules/admin/members/members.routes')},
            {path: 'orders', loadChildren: () => import('app/modules/admin/orders/orders.routes')},
            {path: 'mrp', loadChildren: () => import('app/modules/admin/mrp/mrp.routes')},
            {path: 'tickets', loadChildren: () => import('app/modules/admin/tickets/tickets.routes')},
            {path: 'users', loadChildren: () => import('app/modules/admin/users/users.routes')}
        ]
    }
];
