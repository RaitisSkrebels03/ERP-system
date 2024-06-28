import { Routes } from '@angular/router';
import { MembersListComponent } from './members-list/members-list.component';
import { MemberDetailsComponent } from './member-details/member-details.component';
import { CreateMemberComponent } from './create-member/create-member.component';
import { UpdateMemberComponent } from './update-member/update-member.component';
import { MembersTypesListComponent } from './members-types-list/members-types-list.component';
import { CreateMembersTypeComponent } from './create-members-type/create-members-type.component';
import { UpdateMemberTypeComponent } from './update-member-type/update-member-type.component';
import { MemberTypeDetailsComponent } from './member-type-details/member-type-details.component';

export default [
    {
        path     : '',
        component: MembersListComponent,
    },
    {
        path     : 'details/:id',
        component: MemberDetailsComponent,
    },
    {
        path     : 'create',
        component: CreateMemberComponent,
    },
    {
        path     : 'update/:id',
        component: UpdateMemberComponent,
    },
    {
        path     : 'types',
        component: MembersTypesListComponent,
    },
    {
        path     : 'type/create',
        component: CreateMembersTypeComponent,
    },
    {
        path     : 'type/update/:id',
        component: UpdateMemberTypeComponent,
    },
    {
        path     : 'type/details/:id',
        component: MemberTypeDetailsComponent,
    }
] as Routes;