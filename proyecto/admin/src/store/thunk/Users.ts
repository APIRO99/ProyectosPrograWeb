import { ThunkAction } from "@reduxjs/toolkit"
import { AnyAction } from 'redux'
import { CreateUser, DeleteUser, GetUsers, UpdateUser } from "services/backend"
import { RootState } from 'store'
import { USERS_CREATE, USERS_DELETE, USERS_GETALL, USERS_UPDATE } from 'store/actions'

export const thunkGetUsers =
  (): ThunkAction<void, RootState, unknown, AnyAction> =>
    async (dispatch, store) => {
      GetUsers(store().session.token)
        .then(session => dispatch({ type: USERS_GETALL, payload: session }))
        .catch(error => console.log(error));
    }

export const thunkCreateUser =
  (user: IUser): ThunkAction<void, RootState, unknown, AnyAction> =>
    async (dispatch, store) => {
      CreateUser(store().session.token, user)
        .then(createdUser => dispatch({ type: USERS_CREATE, payload: createdUser }))
        .catch(error => console.log(error));
    }

export const thunkUpdateUser = (user: IUser): ThunkAction<void, RootState, unknown, AnyAction> =>
  async (dispatch, store) => {
    UpdateUser(store().session.token, user)
      .then(user => dispatch({ type: USERS_UPDATE, payload: user }))
      .catch(error => console.log(error));
  }

export const thunkDeleteUser =
  (id: string): ThunkAction<void, RootState, unknown, AnyAction> =>
    async (dispatch, store) => {
      DeleteUser(store().session.token, id)
        .then(user => dispatch({ type: USERS_DELETE, payload: user }))
        .catch(error => console.log(error));
    }

