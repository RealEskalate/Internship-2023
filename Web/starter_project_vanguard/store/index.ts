import { homeApi } from './features/home/home-api'

import { configureStore } from '@reduxjs/toolkit'

const store = configureStore({
  reducer: {
    [homeApi.reducerPath]: homeApi.reducer,
    
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(homeApi.middleware),
})

export default store
// Infer the `RootState` and `AppDispatch` types from the store itself
export type RootState = ReturnType<typeof store.getState>
// Inferred type: {posts: PostsState, comments: CommentsState, users: UsersState}
export type AppDispatch = typeof store.dispatch
