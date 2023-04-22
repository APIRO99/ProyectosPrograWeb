import { createContext, useState, useMemo } from "react";
import { createTheme, ThemeProvider, CssBaseline, Theme } from "@mui/material";
import light from "./light";
import dark from "./dark";

export const getTheme = (mode: string): Theme => {
  const theme = mode === "dark" ? dark : light;
  return createTheme(theme);
};

export const CustomThemeProvider = ({ children }: any) => {
  const theme = useMemo(() => getTheme("light"), []);
  return (
    <>
      {/* // <ThemeProvider theme={theme}> */}
        {/* // <CssBaseline /> */}
        {children}
      {/* // </ThemeProvider> */}
    </>
  );
};
