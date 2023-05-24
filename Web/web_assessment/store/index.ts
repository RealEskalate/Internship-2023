import { configureStore } from '@reduxjs/toolkit'
import { doctorsApi } from './features/doctors/doctors-api'
import { doctorApi } from './features/doctors/doctor-api'

export const store = configureStore({
  reducer: {
    [doctorsApi.reducerPath]: doctorsApi.reducer,
    [doctorApi.reducerPath]: doctorApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(
        doctorsApi.middleware,
        doctorApi.middleware,
    ),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch