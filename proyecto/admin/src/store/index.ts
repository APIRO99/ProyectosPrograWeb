import { configureStore } from '@reduxjs/toolkit';
import reducer from './reducers';

// ==============================|| REDUX - MAIN STORE ||============================== //

const store = configureStore({
  reducer, middleware: getDefaultMiddleware =>
    getDefaultMiddleware({
      thunk: {
        extraArgument: "https://localhost:3000"
      }
    })
});

export { store };

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
