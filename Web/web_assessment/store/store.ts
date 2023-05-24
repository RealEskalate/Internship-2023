import { configureStore } from '@reduxjs/toolkit'
import {doctorsApi} from "@/store/doctors/doctors-api";

export const store = configureStore({
    reducer: {
        [doctorsApi.reducerPath]: doctorsApi.reducer,
    },

    middleware: (getDefaultMiddleware) =>
        getDefaultMiddleware().concat(doctorsApi.middleware),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch