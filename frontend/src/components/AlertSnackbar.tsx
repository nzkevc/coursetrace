import { useState } from "react";
import { Alert, Snackbar } from "@mui/material";

// XXX: HIGHLY LIKELY I MIGHT NOT EVEN USE THIS COMPONENT
export function AlertSnackBar() {
  const [openSnackbar, setOpenSnackbar] = useState(false);

  // const handleAction = (action: () => void) => {
  //   action();
  //   setOpenSnackbar(true);
  // };

  const handleCloseSnackbar = () => {
    setOpenSnackbar(false);
  };

  return (
    <Snackbar
      open={openSnackbar}
      autoHideDuration={6000}
      onClose={handleCloseSnackbar}
    >
      <Alert
        onClose={handleCloseSnackbar}
        severity="success"
        sx={{ width: "100%" }}
      >
        {/* TODO: Add WHATEVER success message I want here */}
      </Alert>
    </Snackbar>
  );
}
