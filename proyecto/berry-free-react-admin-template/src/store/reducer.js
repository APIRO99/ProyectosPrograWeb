import { combineReducers } from 'redux';

// reducer import
import customizationReducer from './customizationReducer';
import propertiesReducer from './PropertiesReducer';

// ==============================|| COMBINE REDUCER ||============================== //

const reducer = combineReducers({
    customization: customizationReducer,
    properties: propertiesReducer
});

export default reducer;
