import { Icon } from '@chakra-ui/react';
import Admin from 'layouts/admin';
import Auth from 'layouts/auth';
import { MdBarChart, MdPerson, MdHome, MdLock } from 'react-icons/md';


// Admin Imports
import Properties from 'views/admin/Properties';
import Users from 'views/admin/Users';

// Auth Imports
// import SignInCentered from 'views/auth/signIn';

const routes: RoutesType[] = [
  {
    name: 'Login Page',
    layout: '/auth',
    path: '/',
    icon: <Icon as={MdLock} width="20px" height="20px" color="inherit" />,
    component: <Auth />,
    children: false,
  },
  {
    name: 'Main Dashboard',
    layout: '/admin',
    path: '/',
    icon: <Icon as={MdBarChart} width="20px" height="20px" color="inherit" />,
    component: <Admin />,
    children: false,
  },
  {
    name: 'Properties',
    layout: '/admin',
    path: '/properties',
    icon: <Icon as={MdHome} width="20px" height="20px" color="inherit" />,
    component: <Properties />,
    children: true,
  },
  {
    name: 'Users',
    layout: '/admin',
    path: '/users',
    icon: <Icon as={MdPerson} width="20px" height="20px" color="inherit" />,
    component: <Users />,
    children: true,
  }
];

export default routes;
