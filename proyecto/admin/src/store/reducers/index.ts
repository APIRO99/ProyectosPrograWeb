import { combineReducers } from 'redux';

// reducer import
import sessionReducer from './sessionReducer';
import usersReducer from './usersReducer';
import propertiesReducer from './propertiesReducer';

// ==============================|| COMBINE REDUCER ||============================== //

const reducer = combineReducers({
  session: sessionReducer,
  users: usersReducer,
  properties: propertiesReducer
});

export default reducer;
