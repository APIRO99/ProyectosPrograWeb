// action - state management
import { AnyAction } from 'redux';
import * as actionTypes from 'store/actions';

const initialState: IState = {
  session: null
};

// ==============================|| USERS REDUCER ||============================== //

const sessionReducer = (state = initialState, action: AnyAction) => {
  switch (action.type) {
    case actionTypes.SESSION_LOGIN:
      return {
        ...state,
        session: {
          user: 'APIRO',
          name: 'Andres Pineda',
          token: 'sadfasdfwaef'
        }
      };

    case actionTypes.SESSION_LOGOUT:
      return {
        ...state,
        session: {
          user: null,
          name: null,
          token: null
        }
      };
      
    default:
      return state;
  }
};

export default sessionReducer;
