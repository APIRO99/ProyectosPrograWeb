import { lazy } from 'react';

// project imports
import MainLayout from 'layout/MainLayout';
import Loadable from 'ui-component/Loadable';

// dashboard routing
const DashboardDefault = Loadable(lazy(() => import('defaultViews/dashboard/Default')));

// Property routing
const PropertyDefault = Loadable(lazy(() => import('views/manageProperites')));

// utilities routing
const UtilsTypography = Loadable(lazy(() => import('defaultViews/utilities/Typography')));
const UtilsColor = Loadable(lazy(() => import('defaultViews/utilities/Color')));
const UtilsShadow = Loadable(lazy(() => import('defaultViews/utilities/Shadow')));
const UtilsMaterialIcons = Loadable(lazy(() => import('defaultViews/utilities/MaterialIcons')));
const UtilsTablerIcons = Loadable(lazy(() => import('defaultViews/utilities/TablerIcons')));

// sample page routing
const SamplePage = Loadable(lazy(() => import('defaultViews/sample-page')));

// ==============================|| MAIN ROUTING ||============================== //

const MainRoutes = {
    path: '/',
    element: <MainLayout />,
    children: [
        {
            path: '/',
            element: <DashboardDefault />
        },
        {
            path: 'properties',
            element: <PropertyDefault />
        },
        {
            path: 'dashboard',
            children: [
                {
                    path: 'default',
                    element: <DashboardDefault />
                }
            ]
        },
        {
            path: 'utils',
            children: [
                {
                    path: 'util-typography',
                    element: <UtilsTypography />
                }
            ]
        },
        {
            path: 'utils',
            children: [
                {
                    path: 'util-color',
                    element: <UtilsColor />
                }
            ]
        },
        {
            path: 'utils',
            children: [
                {
                    path: 'util-shadow',
                    element: <UtilsShadow />
                }
            ]
        },
        {
            path: 'icons',
            children: [
                {
                    path: 'tabler-icons',
                    element: <UtilsTablerIcons />
                }
            ]
        },
        {
            path: 'icons',
            children: [
                {
                    path: 'material-icons',
                    element: <UtilsMaterialIcons />
                }
            ]
        },
        {
            path: 'sample-page',
            element: <SamplePage />
        }
    ]
};

export default MainRoutes;
