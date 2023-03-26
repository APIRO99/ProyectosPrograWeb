import { useRouteError } from "react-router-dom";
import { Link } from "react-router-dom";
import Grid from '@mui/material/Grid';

export default function ErrorPage() {
  const error = useRouteError();
  console.error(error);

  return (
    <Grid container justifyContent="center" alignItems="center" sx={{ height: "100vh" }}>
      <Grid item>
        <h1>Oops!</h1>
        <p>Sorry, an unexpected error has occurred.</p>
        <p>
          <i>{error.statusText || error.message}</i>
        </p>
        <Link to="/">Go back to the home page</Link>
      </Grid>
    </Grid>
  );


  // return (
  //   <div id="error-page">
  //     <h1>Oops!</h1>
  //     <p>Sorry, an unexpected error has occurred.</p>
  //     <p>
  //       <i>{error.statusText || error.message}</i>
  //     </p>
  //     <Link to="/">Go back to the home page</Link>
  //   </div>
  // );
}