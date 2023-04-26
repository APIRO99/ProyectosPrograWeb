import { ThunkAction } from "@reduxjs/toolkit"
import { AnyAction } from 'redux'
import { RootState } from 'store'
import { SESSION_LOGIN } from 'store/actions'

export const thunkLogin =
  (credentials: ILoginData): ThunkAction<void, RootState, unknown, AnyAction> =>
    async dispatch => {
      loginCall(credentials)
        .then(data => ({
          name: data.name,
          username: credentials.username,
          email: data.email,
          token: data.token,
        }))
        .then(session => dispatch({ type: SESSION_LOGIN, payload: session }))
        .catch(error => console.log(error));
    }


const loginCall = async ({ username, password }: ILoginData): Promise<ILoginResponse> => {
  var response = await fetch("http://localhost:5182/login", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ username, password }),
  });
  if (!response.ok) throw new Error( (await response.json()).message);
  return response.json();
}
