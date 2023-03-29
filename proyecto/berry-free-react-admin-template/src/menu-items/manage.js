// assets
import { IconTypography, IconPalette, IconShadow, IconWindmill, IconHome } from '@tabler/icons';

// constant
const icons = {
    IconTypography,
    IconPalette,
    IconShadow,
    IconWindmill,
    IconHome
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
        }
    ]
};

export default manage;
