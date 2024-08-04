import { useContext } from "react";
import { SettingsContext } from "../contexts/SettingsContext";

// Because I'm too lazy to create all these new folders, this goes in services
export const useSettings = () => {
  const context = useContext(SettingsContext);
  if (context === undefined) {
    throw new Error("useSettings must be used within a SettingsProvider");
  }
  return context;
};
