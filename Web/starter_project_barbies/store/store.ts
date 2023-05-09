import { configureStore } from '@reduxjs/toolkit'
import blogsSlice from '@/slices/blogs/blogsSlice'

export const store = configureStore({
  reducer: {
    blogs: blogsSlice,
  }
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
