import { aboutApi } from '@/store/about/about-api'
import { blogApi } from '@/store/blog/blogs-api'
import { teamApi } from '@/store/team/team-api'
import { storyApi } from './story/storys-api'
import { partnersApi } from './story/partners-api'
import { configureStore } from '@reduxjs/toolkit'

export const store = configureStore({
  reducer: {
    [blogApi.reducerPath]: blogApi.reducer,
    [aboutApi.reducerPath]: aboutApi.reducer,
    [teamApi.reducerPath]: teamApi.reducer,
    [storyApi.reducerPath]: storyApi.reducer,
    [partnersApi.reducerPath]: partnersApi.reducer,
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(blogApi.middleware, aboutApi.middleware, teamApi.middleware,storyApi.middleware,partnersApi.middleware),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch