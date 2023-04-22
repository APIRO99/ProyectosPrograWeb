import { ThunkAction } from "@reduxjs/toolkit"
import { AnyAction } from 'redux'
import { RootState } from 'store'
import { SESSION_LOGIN } from 'store/actions'

export const thunkLogin =
  (credentials: ILoginData): ThunkAction<void, RootState, unknown, AnyAction> =>
    async dispatch => {
      await sleep(3000);
      const { email, password } = credentials;
      dispatch({ type: SESSION_LOGIN, payload: { email, password } });
    }


async function sleep(ms: number): Promise<void> {
  await new Promise(resolve => setTimeout(resolve, ms));
}