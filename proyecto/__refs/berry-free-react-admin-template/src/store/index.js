import { configureStore } from '@reduxjs/toolkit';
import reducer from './reducer';
import { propertiesMiddleware } from './propertiesMiddleware';
import { usersMiddleware } from './usersMiddleware';

// ==============================|| REDUX - MAIN STORE ||============================== //

const store = configureStore({ reducer, middleware: [propertiesMiddleware, usersMiddleware] });
const persister = 'Free';

export { store, persister };
