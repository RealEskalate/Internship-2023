import { usersApi } from '@/pages/api/profile'
import { addNewBlogApi } from '@/store/features/blog/add-new-blog-api'
import { configureStore } from '@reduxjs/toolkit'
import { aboutApi } from './about/about-api'
import { successStoryApi } from './features/success-story/success-story-api'

export const store = configureStore({
  reducer: {
    [usersApi.reducerPath]: usersApi.reducer,
    [successStoryApi.reducerPath]: successStoryApi.reducer,
    [addNewBlogApi.reducerPath]: addNewBlogApi.reducer,
    [aboutApi.reducerPath]: aboutApi.reducer,
  },
  middleware: (getDefaultMiddleware) => {
    return getDefaultMiddleware()
      .concat(successStoryApi.middleware)
      .concat(addNewBlogApi.middleware)
      .concat(aboutApi.middleware)
      .concat(usersApi.middleware)
  },
})

export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>
