// action - state management
import { AnyAction } from 'redux';
import * as actionTypes from 'store/actions';

export const initialState: Array<IProperty> = [ ];

// ==============================|| PROPERTIES REDUCER ||============================== //

const propertiesReducer = (state = initialState, action: AnyAction) => {
  switch (action.type) {
    case actionTypes.PROPERTIES_GETALL:
      return [
        ...action.payload
      ];
    case actionTypes.PROPERTIES_CREATE:
      return [
        ...state, 
        action.payload
      ];
    case actionTypes.PROPERTIES_UPDATE:
      return [
        ...state.map((property) => (property.id === action.payload.id)
          ? action.payload
          : property
        )
      ];
    case actionTypes.PROPERTIES_DELETE:
      return [
        ...state.filter((property) => property.id !== action.payload.id)
      ];
    default:
      return state;
  }
};

export default propertiesReducer;
