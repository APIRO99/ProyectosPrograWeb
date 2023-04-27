import { ThunkAction } from "@reduxjs/toolkit"
import { AnyAction } from 'redux'
import { RootState } from 'store'
import { SESSION_LOGIN } from 'store/actions'
import { login } from "services/backend";

export const thunkLogin =
  (credentials: ILoginData): ThunkAction<void, RootState, unknown, AnyAction> =>
    async dispatch => {
      login(credentials)
        .then(data => ({
          name: data.name,
          username: credentials.username,
          email: data.email,
          token: data.token,
        }))
        .then(session => dispatch({ type: SESSION_LOGIN, payload: session }))
        .catch(error => console.log(error));
    }
