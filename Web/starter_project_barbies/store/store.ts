import { configureStore } from '@reduxjs/toolkit'
import { blogApi } from '@/slices/api/blog-api'

export const store = configureStore({
  reducer: {
    // Add the blogApi reducer
    [blogApi.reducerPath]: blogApi.reducer,
  },
  // Adding the blogApi middleware enables caching, invalidation, polling
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(blogApi.middleware),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
