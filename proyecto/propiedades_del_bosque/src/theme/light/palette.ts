import { Color, PaletteColor, PaletteMode } from "@mui/material";
import { Palette } from "@mui/material";

const mode: PaletteMode = 'light';
const contrastThreshold: number = 3;
const tonalOffset: number = 0.2;
const grey: Color = {
    50: '#fafafa',
    100: '#f5f5f5',
    200: '#eeeeee',
    300: '#e0e0e0',
    400: '#bdbdbd',
    500: '#9e9e9e',
    600: '#757575',
    700: '#616161',
    800: '#424242',
    900: '#212121',
    A100: '#d5d5d5',
    A200: '#aaaaaa',
    A400: '#303030',
    A700: '#616161',
}



const palette: Palette = {
    mode,
    contrastThreshold,
    tonalOffset,
    grey,
    getContrastText: (background: string) => {
        return background;
    },
    augmentColor: (color: any) => {
        return color;
    },
    divider: 'rgba(0, 0, 0, 0.12)',
    action: {
        active: 'rgba(0, 0, 0, 0.54)',
        hover: 'rgba(0, 0, 255, 0.5)',
        hoverOpacity: 0.04,
        selected: 'rgba(0, 0, 0, 0.08)',
        selectedOpacity: 0.08,
        disabled: 'rgba(0, 0, 0, 0.26)',
        disabledBackground: 'rgba(0, 0, 0, 0.12)',
        disabledOpacity: 0.38,
        focus: 'rgba(0, 0, 0, 0.12)',
        focusOpacity: 0.12,
        activatedOpacity: 0.12,
    },
    common: {
        black: '#000',
        white: '#fff',
    },
    primary: {
        dark: '#123838',
        main: '#1a5150',
        light: '#477373',
        contrastText: '#ffffff',
    },
    secondary: {
        dark: '#381212',
        main: '#511A1B',
        light: '#734748',
        contrastText: '#ffffff',
    },
    success: {
        main: '#176723',
        light: '#4d8a8a',
        dark: '#003333',
        contrastText: '#ffffff',
    },
    error: {
        main: '#A42727',
        light: '#4d8a8a',
        dark: '#003333',
        contrastText: '#ffffff',
    },
    warning: {
        main: '#A47A27',
        light: '#4d8a8a',
        dark: '#003333',
        contrastText: '#ffffff',
    },
    info: {
        main: '#F4F4F5',
        light: '#4d8a8a',
        dark: '#003333',
        contrastText: '#ffffff',
    },
    background: {
        default: '#F2F2F2',
        paper: "#ffffff",
    },
    text: {
        primary: '#212121',
        secondary: '#565656',
        disabled: 'rgba(79, 79, 79, 0.83)'
    },
};
export default palette;