import { configureStore } from "@reduxjs/toolkit";
import { hospitalsApi } from "./features/hospitals-api";
import { hospitalDetailsApi } from "./features/hospital-details-api";


export const store = configureStore({
    reducer: {
        [hospitalsApi.reducerPath]: hospitalsApi.reducer,
        [hospitalDetailsApi.reducerPath] : hospitalDetailsApi.reducer,

    },
    middleware: (getDefaultMiddleware) =>{
        return getDefaultMiddleware()
        .concat(hospitalsApi.middleware)
        .concat(hospitalDetailsApi.middleware)
    },
},)

export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>