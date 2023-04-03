// action - state management
import * as actionTypes from './actions';

export const initialState = {
    users: []
};

// ==============================|| USERS REDUCER ||============================== //

const usersReducer = (state = initialState, action) => {
    switch (action.type) {
        case actionTypes.GET_USERS:
            return {
                ...state,
                users: action.users
            };
        case actionTypes.ADD_USER:
            return {
                ...state,
                users: [...state.users, action.user]
            };
        case actionTypes.UPDATE_USER:
            return {
                ...state,
                users: state.users.map((user) => {
                    if (user.id === action.user.id) {
                        return action.user;
                    }
                    return user;
                })
            };
        case actionTypes.DELETE_USER:
            return {
                ...state,
                users: state.users.filter((user) => user.id !== action.user.id)
            };
        default:
            return state;
    }
};

export default usersReducer;
