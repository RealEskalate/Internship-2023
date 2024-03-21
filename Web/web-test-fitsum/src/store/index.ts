import { combineReducers, configureStore } from "@reduxjs/toolkit";
import { jokesApi } from "../features/api/JokesApi";
import jokesReducer from "../features/Jokes/JokesSlice";

const appReducer = combineReducers({
    [jokesApi.reducerPath]: jokesApi.reducer,
    jokes: jokesReducer
})
export const store = configureStore({
    reducer: appReducer,
    middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware({}).concat(jokesApi.middleware),
})

export type RootState = ReturnType<typeof appReducer>;
