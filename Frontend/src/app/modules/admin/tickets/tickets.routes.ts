import { Routes } from '@angular/router';
import { TicketsListComponent } from './tickets-list/tickets-list.component';
import { CreateTicketComponent } from './create-ticket/create-ticket.component';
import { UpdateTicketComponent } from './update-ticket/update-ticket.component';
import { TicketDetailsComponent } from './ticket-details/ticket-details.component';

export default [
    {
        path     : '',
        component: TicketsListComponent,
    },
    {
        path     : 'details/:id',
        component: TicketDetailsComponent,
    },
    {
        path     : 'create',
        component: CreateTicketComponent,
    },
    {
        path     : 'update/:id',
        component: UpdateTicketComponent,
    }
] as Routes;