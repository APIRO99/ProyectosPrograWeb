import { configureStore } from '@reduxjs/toolkit';
import reducer from './reducers';
import thunk from 'redux-thunk'

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
