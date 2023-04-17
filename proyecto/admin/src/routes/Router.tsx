import {
  createBrowserRouter,
  RouteObject,
  RouterProvider,
} from "react-router-dom";
import routes from "routes/routes";

const router = createBrowserRouter(
  routes.map<RouteObject>((route): RouteObject => {
    return {
      path: route.layout + route.path,
      element: route.component(),
    };
  })
);

const Router = () => <RouterProvider router={router} />;

export default Router;
