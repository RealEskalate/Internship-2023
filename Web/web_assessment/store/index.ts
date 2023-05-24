import { configureStore } from "@reduxjs/toolkit"
import { api } from "./hackimhub-api"

export const store = configureStore({
    reducer: {
      [api.reducerPath]: api.reducer,
    },
    middleware: (getDefaultMiddleware) => {
      return getDefaultMiddleware()
        .concat(api.middleware)
    },
  },)
  
  export type AppDispatch = typeof store.dispatch
  export type RootState = ReturnType<typeof store.getState>