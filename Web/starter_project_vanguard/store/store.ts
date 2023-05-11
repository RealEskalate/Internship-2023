import { addNewBlogApi } from '@/api/blog/add-new-blog'
import { apiSlice } from '@/features/success-story/success-story-api-slice'
import { configureStore } from '@reduxjs/toolkit'

export const store = configureStore({
  reducer: {
    [apiSlice.reducerPath]: apiSlice.reducer,
    [addNewBlogApi.reducerPath]: addNewBlogApi.reducer,
  },
  middleware: (getDefaultMiddleware) => {
    return getDefaultMiddleware()
      .concat(apiSlice.middleware)
      .concat(addNewBlogApi.middleware)
  },
})

export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>
