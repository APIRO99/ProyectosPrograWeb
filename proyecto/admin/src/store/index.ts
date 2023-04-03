import { configureStore } from '@reduxjs/toolkit';
import reducer from './reducers';
// import { fetchPropertiesMiddleware } from './Middleware';

// ==============================|| REDUX - MAIN STORE ||============================== //

// const store = configureStore({ reducer, middleware: [fetchPropertiesMiddleware] });
const store = configureStore({ reducer });

export { store };
