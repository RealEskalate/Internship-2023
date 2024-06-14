import { configureStore, getDefaultMiddleware } from '@reduxjs/toolkit'
import {doctorApi} from './doctor/doctor-api'
export const store = configureStore({
  reducer: {
    [doctorApi.reducerPath]:doctorApi.reducer
  },
  middleware: (getDefaultMiddleware) => 
        getDefaultMiddleware().concat(doctorApi.middleware)
})

// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch