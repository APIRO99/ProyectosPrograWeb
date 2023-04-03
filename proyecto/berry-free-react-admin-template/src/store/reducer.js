import { combineReducers } from 'redux';

// reducer import
import customizationReducer from './customizationReducer';
import propertiesReducer from './propertiesReducer';
import usersReducer from './usersReducer';

// ==============================|| COMBINE REDUCER ||============================== //

const reducer = combineReducers({
    customization: customizationReducer,
    properties: propertiesReducer,
    users: usersReducer
});

export default reducer;
