import { configureStore } from '@reduxjs/toolkit'


import { doctorsApi } from '../store/features/doctors/doctors-api'
import { doctorsDetailApi } from './features/doctors/doctors-detail-api'


export const store = configureStore({
  reducer: {
    [doctorsApi.reducerPath]: doctorsApi.reducer,
    [doctorsDetailApi.reducerPath]: doctorsDetailApi.reducer,

  },
  middleware: (getDefaultMiddleware) => {
    return getDefaultMiddleware()
      .concat(doctorsApi.middleware)
      .concat(doctorsDetailApi.middleware)

  },
},)

export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>
