import { Routes } from '@angular/router';
import { CreateThirdpartyComponent } from './create-thirdparty/create-thirdparty.component';
import { ThirdpartiesListComponent } from './thirdparties-list/thirdparties-list.component';
import { ThirdpartyDetailsComponent } from './thirdparty-details/thirdparty-details.component';
import { UpdateThirdpartyComponent } from './update-thirdparty/update-thirdparty.component';
import { CreateContactComponent } from './create-contact/create-contact.component';
import { UpdateContactComponent } from './update-contact/update-contact.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { ContactsListComponent } from './contacts-list/contacts-list.component';
export default [
    {
        path     : '',
        component: ThirdpartiesListComponent,
    },
    {
        path     : 'details/:id',
        component: ThirdpartyDetailsComponent,
    },
    {
        path     : 'create',
        component: CreateThirdpartyComponent,
    },
    {
        path     : 'update/:id',
        component: UpdateThirdpartyComponent,
    },{
        path     : 'contacts',
        component: ContactsListComponent,
    },
    {
        path     : 'contacts/details/:id',
        component: ContactDetailsComponent,
    },
    {
        path     : 'contacts/create',
        component: CreateContactComponent,
    },
    {
        path     : 'contacts/update/:id',  
        component: UpdateContactComponent,
    }
] as Routes;