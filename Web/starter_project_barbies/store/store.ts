import { aboutApi } from '@/store/about/about-api'
import { blogApi } from '@/store/blog/blogs-api'
import { configureStore } from '@reduxjs/toolkit'
export const store = configureStore({
  reducer: {
    [blogApi.reducerPath]: blogApi.reducer,
    [aboutApi.reducerPath]: aboutApi.reducer
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(blogApi.middleware, aboutApi.middleware),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch