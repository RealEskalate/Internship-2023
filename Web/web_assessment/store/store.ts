import { hospitalApi } from './hospital/hospital-api' 
import { configureStore } from '@reduxjs/toolkit'

export const store = configureStore({
  reducer: {
    [hospitalApi.reducerPath]: hospitalApi.reducer,
  },
  middleware: (getDefaultMiddleware) => {
    return getDefaultMiddleware()
      .concat(hospitalApi.middleware)

  },
},)

export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>