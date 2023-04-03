import Admin from 'layouts/admin'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Admin />,
  },
]);

function Router() {
  return (
      <RouterProvider router={router} />
  );
}

export default Router;
