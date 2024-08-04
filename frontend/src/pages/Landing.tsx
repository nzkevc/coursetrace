import { Button, Typography } from "@mui/material";
import { Link } from "react-router-dom";

export default function Landing() {
  return (
    <div style={{ textAlign: "center", marginTop: "20vh" }}>
      <Typography variant="h1" component="h1" gutterBottom>
        CourseTrace
      </Typography>
      <Typography variant="h4" component="h2" gutterBottom>
        A simple way to manage your courses and assignments
      </Typography>
      {/* Add some space here */}
      <div style={{ marginBottom: "2rem" }}></div>
      <Button
        variant="contained"
        color="primary"
        component={Link}
        to="/dashboard"
      >
        Go to Dashboard
      </Button>
    </div>
  );
}
