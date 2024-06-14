// write a store configuration for react-redux toolkit with typescript
import { configureStore, getDefaultMiddleware } from "@reduxjs/toolkit";


import { doctorApi } from './features/doctors/doctor-api';
import doctorSlice from "./features/doctors/doctor-slice";

export const store = configureStore({
    reducer: {
        doctorId: doctorSlice,
        [doctorApi.reducerPath]: doctorApi.reducer,
    },
    middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(doctorApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
