import Home from "@src/pages/Home/Home";
import ErrorPage from "@src/pages/Error/Error";

import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
    errorElement: <ErrorPage />,
  },
]);


const Router = () => {
  return (
    <RouterProvider router={router} />
  );
}

export default Router;
