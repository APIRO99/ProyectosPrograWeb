import {
    POPULATE_USERS,
    PUT_UPDATE_USERS,
    POST_CREATE_USERS,
    DELETE_DELETE_USERS,
    GET_USERS,
    ADD_USER,
    UPDATE_USER,
    DELETE_USER
} from './actions';

export const usersMiddleware =
    ({ dispatch }) =>
    (next) =>
    (action) => {
        if (action.type === POPULATE_USERS) {
            fetch('http://localhost:5182/users')
                .then((response) => response.json())
                .then((users) => {
                    dispatch({ type: GET_USERS, users });
                });
        }
        if (action.type === POST_CREATE_USERS) {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(action.user)
            };
            fetch('http://localhost:5182/users', requestOptions)
                .then((response) => response.json())
                .then((user) => {
                    dispatch({ type: ADD_USER, user });
                });
        }
        if (action.type === PUT_UPDATE_USERS) {
            const requestOptions = {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(action.user)
            };
            fetch('http://localhost:5182/users', requestOptions)
                .then((response) => response.json())
                .then((users) => {
                    dispatch({ type: UPDATE_USER, user });
                });
        }
        if (action.type === DELETE_DELETE_USERS) {
            const requestOptions = {
                method: 'DELETE'
            };
            fetch('http://localhost:5182/users/' + action.user.id, requestOptions)
                .then((response) => {
                    console.log('response', response);
                    response.json();
                })
                .then((users) => {
                    dispatch({ type: DELETE_USER, user: action.user });
                });
        }

        return next(action);
    };
