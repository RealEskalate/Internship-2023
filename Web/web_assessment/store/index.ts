import { configureStore } from "@reduxjs/toolkit";
import { doctorsApi } from "./features/doctor/doctors-api"
import { doctorDetailApi } from "./features/doctor/doctor-detail-api";


export const store = configureStore({
    reducer: {
        [doctorsApi.reducerPath]: doctorsApi.reducer,
        [doctorDetailApi.reducerPath] : doctorDetailApi.reducer,

    },
    middleware: (getDefaultMiddleware) =>{
        return getDefaultMiddleware()
        .concat(doctorsApi.middleware)
        .concat(doctorDetailApi.middleware)
    },
},)

export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>