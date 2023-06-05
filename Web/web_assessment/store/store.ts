import { configureStore } from '@reduxjs/toolkit'
import { hospitalsApi } from '@/store/hospitals/hospitals-api'

export const store = configureStore({
  reducer: {
    [hospitalsApi.reducerPath]: hospitalsApi.reducer,
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(hospitalsApi.middleware),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch