
import { doctorsApi } from './features/doctors/doctors-api'
import { configureStore } from '@reduxjs/toolkit'

export const store = configureStore({
  reducer: {
    [doctorsApi.reducerPath]: doctorsApi.reducer,

  },
  middleware: (getDefaultMiddleware) => {
    return getDefaultMiddleware()
      
      .concat(doctorsApi.middleware)

  },
},)

export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>
