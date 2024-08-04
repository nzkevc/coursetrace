import React, { createContext, useState, ReactNode } from "react";

interface SettingsContextProps {
  isDarkTheme: boolean;
  toggleDarkTheme: () => void;
}

export const SettingsContext = createContext<SettingsContextProps | undefined>(
  undefined
);

export const SettingsProvider: React.FC<{ children: ReactNode }> = ({
  children,
}) => {
  const [isDarkTheme, setDarkTheme] = useState(false);

  const toggleDarkTheme = () => {
    setDarkTheme(!isDarkTheme);
  };

  return (
    <SettingsContext.Provider
      value={{
        isDarkTheme,
        toggleDarkTheme,
      }}
    >
      {children}
    </SettingsContext.Provider>
  );
};
