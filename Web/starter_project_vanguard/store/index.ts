
import { addNewBlogApi } from '@/store/features/blog/add-new-blog-api'
import { configureStore } from '@reduxjs/toolkit'
import { aboutApi } from './about/about-api'
import { successStoryApi } from '@/store/features/success-story/success-story-api'
import { getBlogs } from '@/store/features/blog/blogs-api'
import { homeApi } from '@/store/features/home/home-api'
import { userApi } from '@pages/api/profile'
import { singleBlogApi } from '@/store/features/blog/single-blog-api'
import { teamsApi } from '@/store/features/teams/teams-api'

export const store = configureStore({
  reducer: {
    [successStoryApi.reducerPath]: successStoryApi.reducer,
    [addNewBlogApi.reducerPath]: addNewBlogApi.reducer,
    [aboutApi.reducerPath]: aboutApi.reducer,
    [getBlogs.reducerPath]: getBlogs.reducer,
    [homeApi.reducerPath]: homeApi.reducer,
    [teamsApi.reducerPath]: teamsApi.reducer,
    [userApi.reducerPath]: userApi.reducer,
    [singleBlogApi.reducerPath]: singleBlogApi.reducer,
  },
  middleware: (getDefaultMiddleware) => {
    return getDefaultMiddleware()
      .concat(successStoryApi.middleware)
      .concat(addNewBlogApi.middleware)
      .concat(aboutApi.middleware)
      .concat(getBlogs.middleware)
      .concat(homeApi.middleware)
      .concat(teamsApi.middleware)
      .concat(userApi.miidleware)
      .concat(singleBlogApi.middleware)

  },
},)

export type AppDispatch = typeof store.dispatch
export type RootState = ReturnType<typeof store.getState>
