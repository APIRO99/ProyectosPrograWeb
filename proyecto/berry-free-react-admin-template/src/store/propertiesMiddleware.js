import {
    GET_PROPERTIES,
    POPULATE_PROPERTIES,
    PUT_UPDATE_PROPERTIES,
    DELETE_DELETE_PROPERTIES,
    DELETE_PROPERTY,
    POST_CREATE_PROPERTIES,
    ADD_PROPERTY
} from './actions';

export const propertiesMiddleware =
    ({ dispatch }) =>
    (next) =>
    (action) => {
        console.log('propertiesMiddleware', action);
        if (action.type === POPULATE_PROPERTIES) {
            fetch('http://localhost:5182/property')
                .then((response) => response.json())
                .then((properties) => {
                    dispatch({ type: GET_PROPERTIES, properties });
                });
        }
        if (action.type === POST_CREATE_PROPERTIES) {
            const requestOptions = {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(action.property)
            };
            fetch('http://localhost:5182/property', requestOptions)
                .then((response) => response.json())
                .then((property) => {
                    dispatch({ type: ADD_PROPERTY, property });
                });
        }
        if (action.type === PUT_UPDATE_PROPERTIES) {
            const requestOptions = {
                method: 'PUT',
                headers: { 'Content-Type': 'application/json' },
                body: JSON.stringify(action.property)
            };
            fetch('http://localhost:5182/property', requestOptions)
                .then((response) => response.json())
                .then((properties) => {
                    dispatch({ type: UPDATE_PROPERTY, property });
                });
        }
        if (action.type === DELETE_DELETE_PROPERTIES) {
            const requestOptions = {
                method: 'DELETE'
            };
            fetch('http://localhost:5182/property/' + action.property.id, requestOptions)
                .then((response) => {
                    console.log('response', response);
                    response.json();
                })
                .then((properties) => {
                    dispatch({ type: DELETE_PROPERTY, property: action.property });
                });
        }

        return next(action);
    };
