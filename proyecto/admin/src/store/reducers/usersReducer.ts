// action - state management
import { AnyAction } from 'redux';
import * as actionTypes from 'store/actions';

export const initialState: Array<IUser> = [ ];

// ==============================|| USERS REDUCER ||============================== //

const usersReducer = (state = initialState, action: AnyAction) => {
  switch (action.type) {
    case actionTypes.USERS_GETALL:
      return [
        ...action.payload
      ];
    case actionTypes.USERS_CREATE:
      return [
        ...state, 
        action.payload
      ];
    case actionTypes.USERS_UPDATE:
      return [
        ...state.map((user) => (user.id === action.payload.id)
          ? action.payload
          : user
        )
      ];
    case actionTypes.USERS_DELETE:
      return [
        ...state.filter((user) => user.id !== action.payload.id)
      ];
    default:
      return state;
  }
};

export default usersReducer;
