import { Routes } from '@angular/router';
import { ProductsListComponent } from 'app/modules/admin/products/products-list/products-list.component';
import { ProductDetailsComponent } from './product-details/product-details.component';
import { CreateProductComponent } from './create-product/create-product.component';
import { UpdateProductComponent } from './update-product/update-product.component';
import { CreateCategoryComponent } from './create-category/create-category.component';

export default [
    {
        path     : '',
        component: ProductsListComponent,
    },
    {
        path     : 'details/:id',
        component: ProductDetailsComponent,
    },
    {
        path     : 'create',
        component: CreateProductComponent,
    },
    {
        path     : 'update/:id',
        component: UpdateProductComponent,
    },
    {
        path     : 'createCategory',
        component: CreateCategoryComponent,
    }
] as Routes;