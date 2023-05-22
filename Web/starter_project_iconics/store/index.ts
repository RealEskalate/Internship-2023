import { configureStore } from '@reduxjs/toolkit'
import { tagsApi } from './features/blog/tags-api'
import tagsSlice from './features/blog/tags-slice'
import { blogsApi } from './features/blogs/blogs-api'
import { impactStoriesApi } from './features/home/impact-stories/impact-stories-api'
import impactStoriesSlice from './features/home/impact-stories/impact-stories-slice'
import { storyApi } from './features/story/success-stories-api'
import { teamMembersApi } from './features/team-members/team-members-api'

export const store = configureStore({
  reducer: {
    tag: tagsSlice,
    impactStories: impactStoriesSlice,
    [storyApi.reducerPath]: storyApi.reducer,
    [impactStoriesApi.reducerPath]: impactStoriesApi.reducer,
    [blogsApi.reducerPath]: blogsApi.reducer,
    [tagsApi.reducerPath]: tagsApi.reducer,
    [teamMembersApi.reducerPath]: teamMembersApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(
      impactStoriesApi.middleware,
      storyApi.middleware,
      blogsApi.middleware,
      tagsApi.middleware
      teamMembersApi.middleware
    ),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
