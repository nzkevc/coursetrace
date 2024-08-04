import { Outlet } from "react-router-dom";
import NavToolbar from "./NavToolbar";

export function Layout() {
  return (
    <>
      <NavToolbar />
      <Outlet />
    </>
  );
}
