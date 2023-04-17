import { combineReducers } from 'redux';

// reducer import
import sessionReducer from './sessionReducer';
// import propertiesReducer from './PropertiesReducer';

// ==============================|| COMBINE REDUCER ||============================== //

const reducer = combineReducers({
  session: sessionReducer
  // properties: propertiesReducer
});

export default reducer;
