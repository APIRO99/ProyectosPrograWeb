// assets
import { IconHome, IconUser } from '@tabler/icons';

// constant
const icons = {
    IconHome,
    IconUser
};

// ==============================|| Manage MENU ITEMS ||============================== //

const manage = {
    id: 'manage',
    title: 'Manage Properties',
    type: 'group',
    children: [
        {
            id: 'properties',
            title: 'Properties',
            type: 'item',
            url: '/properties',
            icon: icons.IconHome,
            breadcrumbs: false
        },
        {
            id: 'users',
            title: 'Users',
            type: 'item',
            url: '/users',
            icon: icons.IconUser,
            breadcrumbs: false
        }
    ]
};

export default manage;
