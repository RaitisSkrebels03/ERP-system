import { Routes } from '@angular/router';
import { UserDetailsComponent } from './user-details/user-details.component';
import { UpdateUserComponent } from './update-user/update-user.component';
import { UsersListComponent } from './users-list/users-list.component';
import { UserCurrentDetailsComponent } from './user-current-details/user-current-details.component';
import { CreateUserComponent } from './create-user/create-user.component';

export default [
    {
        path     : '',
        component: UsersListComponent,
    },
    {
        path     : 'create',
        component: CreateUserComponent,
    },
    {
        path     : 'details/:id',
        component: UserDetailsComponent,
    },
    {
        path     : 'current',
        component: UserCurrentDetailsComponent,
    },
    {
        path     : 'update/:id',
        component: UpdateUserComponent,
    },
] as Routes;