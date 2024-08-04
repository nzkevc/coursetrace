import { createBrowserRouter, RouterProvider } from "react-router-dom";
import Landing from "./pages/Landing";
import Dashboard from "./pages/Dashboard";
import Semesters from "./pages/Semesters";
import Courses from "./pages/Courses";
import Assignments from "./pages/Assignments";
import SingleAssignment from "./pages/SingleAssignment";
import ErrorPage from "./pages/ErrorPage";
import { Layout } from "./components/Layout";
import { createTheme, ThemeProvider } from "@mui/material";
import { useSettings } from "./services/useSettings";

function App() {
  const { isDarkTheme } = useSettings();

  const theme = createTheme({
    palette: {
      mode: isDarkTheme ? "dark" : "light",
      primary: {
        main: "#2C3E50",
      },
      secondary: {
        main: "#E74C3C",
      },
    },
  });

  const router = createBrowserRouter([
    {
      path: "/",
      element: <Layout />,
      errorElement: <ErrorPage />,
      children: [
        {
          index: true,
          element: <Landing />,
        },
        {
          path: "dashboard",
          element: <Dashboard />,
        },
        {
          path: "semesters",
          element: <Semesters />,
        },
        {
          path: "courses",
          element: <Courses />,
        },
        {
          path: "assignments",
          element: <Assignments />,
        },
        {
          path: "assignments/:id",
          element: <SingleAssignment />,
        },
      ],
    },
  ]);

  return (
    <>
      <ThemeProvider theme={theme}>
        <RouterProvider router={router} fallbackElement={<p>Loading...</p>} />
      </ThemeProvider>
    </>
  );
}

export default App;
