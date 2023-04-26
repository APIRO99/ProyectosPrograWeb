import {
  createBrowserRouter,
  Navigate,
  RouteObject,
  RouterProvider,
} from "react-router-dom";
import routes from "routes/routes";

const router = createBrowserRouter([
  ...routes.filter(el => !el.children).map<RouteObject>((route): RouteObject => {
    const rt: RouteObject = {
      path: route.layout + route.path,
      element: route.component,
      children: [
        ...routes.filter(el => el.children && el.layout === route.layout).map<RouteObject>((route): RouteObject => {
          const rtch: RouteObject = {
            path: route.path.substring(1),
            element: route.component,
          };
          return rtch;
        }),
      ]
    };
    return rt;
  }),
  {
    path: "*",
    element: <Navigate to="/auth" />
  }
]);

const Router = () => <RouterProvider router={router} />;

export default Router;
