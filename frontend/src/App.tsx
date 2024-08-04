import { createBrowserRouter, RouterProvider } from "react-router-dom";

import Landing from "./pages/Landing";
import Dashboard from "./pages/Dashboard";
import Semesters from "./pages/Semesters";
import Courses from "./pages/Courses";
import Assignments from "./pages/Assignments";
import SingleAssignment from "./pages/SingleAssignment";
import ErrorPage from "./pages/ErrorPage";

function App() {
  const router = createBrowserRouter([
    {
      path: "/",
      element: <Landing />,
      errorElement: <ErrorPage />,
    },
    {
      path: "/dashboard",
      element: <Dashboard />,
    },
    {
      path: "/semesters",
      element: <Semesters />,
    },
    {
      path: "/courses",
      element: <Courses />,
    },
    {
      path: "/assignments",
      element: <Assignments />,
    },
    {
      path: "/assignments/:id",
      element: <SingleAssignment />,
    },
  ]);

  return (
    <>
      <RouterProvider router={router} fallbackElement={<p>Loading...</p>} />
    </>
  );
}

export default App;
