import { TypedUseSelectorHook, useDispatch, useSelector } from 'react-redux'
import type { RootState, AppDispatch } from './index'

// Use throughout your app instead of plain `useDispatch` and `useSelector`
type DispatchFunc = () => AppDispatch
export const useTypedDispatch: DispatchFunc = useDispatch
export const useTypedSelector: TypedUseSelectorHook<RootState> = useSelector
