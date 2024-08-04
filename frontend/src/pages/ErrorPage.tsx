import { Box, Typography } from "@mui/material";
import { useRouteError } from "react-router-dom";

export default function ErrorPage() {
  // eslint-disable-next-line @typescript-eslint/no-explicit-any
  const error: any = useRouteError();
  console.error(error);

  return (
    <Box display="flex" justifyContent="center" alignItems="center" height="100vh">
      <Box textAlign="center" >
        <Typography variant="h2" gutterBottom>Oops!</Typography>
        <Typography variant="body1">
          Sorry, an unexpected error has occurred. <br />
          Error: {error.statusText || error.message}
        </Typography>
      </Box>
    </Box>
  );
}