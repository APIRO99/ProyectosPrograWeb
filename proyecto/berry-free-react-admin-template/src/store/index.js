import { configureStore } from '@reduxjs/toolkit';
import reducer from './reducer';
import { fetchPropertiesMiddleware } from './Middleware';

// ==============================|| REDUX - MAIN STORE ||============================== //

const store = configureStore({ reducer, middleware: [fetchPropertiesMiddleware] });
const persister = 'Free';

export { store, persister };
