/* eslint-disable */
import { FuseNavigationItem } from '@fuse/components/navigation';

export const defaultNavigation: FuseNavigationItem[] = [ 
    {
        id   : 'poducts',
        title: 'Produkti',
        type : 'basic',
        icon : 'heroicons_outline:cube',
        link : '/products'
    },
    {
        id   : 'projects',
        title: 'Projekti',
        type : 'collapsable',
        icon : 'heroicons_outline:chart-pie'
    },
    {
        id   : 'thirdparties',
        title: 'Trešās puses',
        type : 'collapsable',
        icon : 'heroicons_outline:users',
        children: [
            {
                id   : 'thirdparties.thirdparties',
                title: 'Trešās puses',
                type : 'basic',
                link : '/thirdparties'
            },
            {
                id   : 'thirdparties.contacts',
                title: 'Kontakti',
                type : 'basic',
                link : '/thirdparties/contacts'
            }
        ]
    },
    {
        id   : 'members',
        title: 'Dalībnieki',
        type : 'collapsable',
        icon : 'heroicons_outline:users',
        children: [
            {
                id   : 'members.members',
                title: 'Dalībnieki',
                type : 'basic',
                link : '/members'
            },
            {
                id   : 'members.types',
                title: 'Dalībnieku veidi',
                type : 'basic',
                link : '/members/types'
            }
        ]
    },
    {
        id   : 'orders',
        title: 'Pasūtījumi',
        type : 'basic',
        icon : 'reorder',
        link : '/orders/sales'
    },
    {
        id   : 'MRP',
        title: 'Materiālu prasību plānošana(MRP)',
        type : 'collapsable',
        icon : 'inventory',
        children: [
            {
                id   : 'MRP.Bills',
                title: 'Materiālu rēķini',
                type : 'basic',
                link : '/mrp/bills'
            },
            {
                id   : 'MRP.Orders',
                title: 'Ražošanas pasūtījumi',
                type : 'basic',
                link : '/mrp/orders'
            }
        ]
    },
    {
        id   : 'tickets',
        title: 'Pieprasījumi',
        type : 'basic',
        icon : 'description',
        link : '/tickets'
    },
];
export const compactNavigation: FuseNavigationItem[] = [
    {
        id   : 'poducts',
        title: 'Produkti',
        type : 'basic',
        icon : 'heroicons_outline:cube',
        link : '/products'
    },
    {
        id   : 'projects',
        title: 'Projekti',
        type : 'basic',
        icon : 'heroicons_outline:chart-pie',
        link : '/projects'
    },
    {
        id   : 'thirdparties',
        title: 'Trešās puses',
        type : 'collapsable',
        icon : 'heroicons_outline:users',
        children: [
            {
                id   : 'thirdparties.thirdparties',
                title: 'Trešās puses',
                type : 'basic',
                link : '/thirdparties'
            },
            {
                id   : 'thirdparties.contacts',
                title: 'Kontakti',
                type : 'basic',
                link : '/thirdparties/contacts'
            }
        ]
    },
    {
        id   : 'members',
        title: 'Dalībnieki',
        type : 'collapsable',
        icon : 'heroicons_outline:users',
        children: [
            {
                id   : 'members.members',
                title: 'Dalībnieki',
                type : 'basic',
                link : '/members'
            },
            {
                id   : 'members.types',
                title: 'Dalībnieku veidi',
                type : 'basic',
                link : '/members/types'
            }
        ]
    },
    {
        id   : 'orders',
        title: 'Pasūtījumi',
        type : 'basic',
        icon : 'reorder',
        link : '/orders/sales'
    },
    {
        id   : 'MRP',
        title: 'Materiālu prasību plānošana(MRP)',
        type : 'collapsable',
        icon : 'inventory',
        children: [
            {
                id   : 'MRP.Bills',
                title: 'Materiālu rēķini',
                type : 'basic',
                link : '/mrp/bills'
            },
            {
                id   : 'MRP.Orders',
                title: 'Ražošanas pasūtījumi',
                type : 'basic',
                link : '/mrp/orders'
            }
        ]
    },
    {
        id   : 'tickets',
        title: 'Pieprasījumi',
        type : 'basic',
        icon : 'description',
        link : '/tickets'
    },
];
export const futuristicNavigation: FuseNavigationItem[] = [
    {
        id   : 'poducts',
        title: 'Produkti',
        type : 'basic',
        icon : 'heroicons_outline:cube',
        link : '/products'
    },
    {
        id   : 'projects',
        title: 'Projekti',
        type : 'basic',
        icon : 'heroicons_outline:chart-pie',
        link : '/projects'
    },
    {
        id   : 'thirdparties',
        title: 'Trešās puses',
        type : 'collapsable',
        icon : 'heroicons_outline:users',
        children: [
            {
                id   : 'thirdparties.thirdparties',
                title: 'Trešās puses',
                type : 'basic',
                link : '/thirdparties'
            },
            {
                id   : 'thirdparties.contacts',
                title: 'Kontakti',
                type : 'basic',
                link : '/thirdparties/contacts'
            }
        ]
    },
    {
        id   : 'members',
        title: 'Dalībnieki',
        type: 'collapsable',
        icon : 'heroicons_outline:users',
        children: [
            {
                id   : 'members.members',
                title: 'Dalībnieki',
                type : 'basic',
                link : '/members'
            },
            {
                id   : 'members.types',
                title: 'Dalībnieku veidi',
                type : 'basic',
                link : '/members/types'
            }
        ]
    },
    {
        id   : 'orders',
        title: 'Pasūtījumi',
        type : 'basic',
        icon : 'reorder',
        link : '/orders/sales'
    },
    {
        id   : 'MRP',
        title: 'Materiālu prasību plānošana(MRP)',
        type : 'collapsable',
        icon : 'inventory',
        children: [
            {
                id   : 'MRP.Bills',
                title: 'Materiālu rēķini',
                type : 'basic',
                link : '/mrp/bills'
            },
            {
                id   : 'MRP.Orders',
                title: 'Ražošanas pasūtījumi',
                type : 'basic',
                link : '/mrp/orders'
            }
        ]
    },
    {
        id   : 'tickets',
        title: 'Pieprasījumi',
        type : 'basic',
        icon : 'description',
        link : '/tickets'
    },
];
export const horizontalNavigation: FuseNavigationItem[] = [
    {
        id   : 'poducts',
        title: 'Produkti',
        type : 'basic',
        icon : 'heroicons_outline:cube',
        link : '/products'
    },
    {
        id   : 'projects',
        title: 'Projekti',
        type : 'basic',
        icon : 'heroicons_outline:chart-pie',
        link : '/projects'
    },
    {
        id   : 'thirdparties',
        title: 'Trešās puses',
        type : 'collapsable',
        icon : 'heroicons_outline:users',
        children: [
            {
                id   : 'thirdparties.thirdparties',
                title: 'Trešās puses',
                type : 'basic',
                link : '/thirdparties'
            },
            {
                id   : 'thirdparties.contacts',
                title: 'Kontakti',
                type : 'basic',
                link : '/thirdparties/contacts'
            }
        ]
    },
    {
        id   : 'members',
        title: 'Dalībnieki',
        type : 'collapsable',
        icon : 'heroicons_outline:users',
        children: [
            {
                id   : 'orders.sales',
                title: 'Pārdošanas pasūtījums',
                type : 'basic',
                link : '/orders/sales'
            },
            {
                id   : 'orders.purchase',
                title: 'Pirkuma pasūtījums',
                type : 'basic',
                link : '/orders/sales'
            }
        ]
    },
    {
        id   : 'orders',
        title: 'Pasūtījumi',
        type : 'basic',
        icon : 'reorder',
        link : '/orders/sales'
    },
    {
        id   : 'MRP',
        title: 'Materiālu prasību plānošana(MRP)',
        type : 'collapsable',
        icon : 'inventory',
        children: [
            {
                id   : 'MRP.Bills',
                title: 'Materiālu rēķini',
                type : 'basic',
                link : '/mrp/bills'
            },
            {
                id   : 'MRP.Orders',
                title: 'Ražošanas pasūtījumi',
                type : 'basic',
                link : '/mrp/orders'
            }
        ]
    },
    {
        id   : 'tickets',
        title: 'Pieprasījumi',
        type : 'basic',
        icon : 'description',
        link : '/tickets'
    },
];
