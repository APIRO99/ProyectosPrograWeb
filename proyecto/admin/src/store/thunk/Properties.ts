import { ThunkAction } from "@reduxjs/toolkit"
import { AnyAction } from 'redux'
import { CreateProperty, DeleteProperty, GetProperties, SaveImage, UpdateProperty } from "services/backend"
import { RootState } from 'store'
import { PROPERTIES_CREATE, PROPERTIES_DELETE, PROPERTIES_GETALL, PROPERTIES_UPDATE } from 'store/actions'

export const thunkGetProperties =
  (): ThunkAction<void, RootState, unknown, AnyAction> =>
    async (dispatch, store) => {
      GetProperties(store().session.token)
        .then(session => dispatch({ type: PROPERTIES_GETALL, payload: session }))
        .catch(error => console.log(error));
    }

export const thunkCreateProperty =
  (property: IProperty, image: File): ThunkAction<void, RootState, unknown, AnyAction> =>
    async (dispatch, store) => {
      SaveImage(image)
        .then(resp => {
          property.photo = `/storage/images/${resp.filename}`;
          return property;
        })
        .then(property => CreateProperty(store().session.token, property))
        .then(createdProperty => dispatch({ type: PROPERTIES_CREATE, payload: createdProperty }))
        .catch(error => console.log(error));
    }

export const thunkUpdateProperty = 
(property: IProperty, image: File): ThunkAction<void, RootState, unknown, AnyAction> =>
  async (dispatch, store) => {
    if (image)
      SaveImage(image)
        .then(resp => {
          property.photo = `/storage/images/${resp.filename}`;
          return property;
        })
        .then(property => UpdateProperty(store().session.token, property))
        .then(property => dispatch({ type: PROPERTIES_UPDATE, payload: property }))
        .catch(error => console.log(error));
    else
      UpdateProperty(store().session.token, property)
        .then(property => dispatch({ type: PROPERTIES_UPDATE, payload: property }))
        .catch(error => console.log(error));
  }

export const thunkDeleteProperty =
  (id: number): ThunkAction<void, RootState, unknown, AnyAction> =>
    async (dispatch, store) => {
      DeleteProperty(store().session.token, id)
        .then(property => dispatch({ type: PROPERTIES_DELETE, payload: property }))
        .catch(error => console.log(error));
    }




// ==============================|| PRIVATE ||============================== //


async function createFileFromUrl(url: string, filename: string): Promise<File> {
  const response = await fetch(url);
  const blob = await response.blob();
  return new File([blob], filename);
}