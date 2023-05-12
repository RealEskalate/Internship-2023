import { addNewBlogApi } from '@/api/blog/add-new-blog'
import { configureStore } from '@reduxjs/toolkit'
import { successStoryApi } from './features/success-story/success-story-api'

export const store = configureStore({
  reducer: {
    [successStoryApi.reducerPath]: successStoryApi.reducer,
    [addNewBlogApi.reducerPath]: addNewBlogApi.reducer,
  },
  middleware: (getDefaultMiddleware) => {
    return getDefaultMiddleware()
      .concat(successStoryApi.middleware)
      .concat(addNewBlogApi.middleware)
  },
})

export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>
