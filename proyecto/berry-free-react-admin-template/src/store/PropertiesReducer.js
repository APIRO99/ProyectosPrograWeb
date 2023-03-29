// action - state management
import * as actionTypes from './actions';

export const initialState = {
    properties: []
};

// ==============================|| PROPERTIES REDUCER ||============================== //

const customizationReducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.GET_PROPERTIES:
            return {
                ...state,
                properties: action.properties
            };
        case actionTypes.ADD_PROPERTY:
            return {
                ...state,
                properties: [...state.properties, action.property]
            };
        case actionTypes.UPDATE_PROPERTY:
            return {
                ...state,
                properties: state.properties.map((property) => {
                    if (property.id === action.property.id) {
                        return action.property;
                    }
                    return property;
                })
            };
        case actionTypes.DELETE_PROPERTY:
            return {
                ...state,
                properties: state.properties.filter((property) => property.id !== action.property.id)
            };
        default:
            return state;
    }
};

export default customizationReducer;
