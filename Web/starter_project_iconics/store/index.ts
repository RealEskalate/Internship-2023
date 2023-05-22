import { configureStore } from '@reduxjs/toolkit'
import { blogsApi } from './features/blogs/blogs-api'
import { impactStoriesApi } from './features/home/impact-stories/impact-stories-api'
import impactStoriesSlice from './features/home/impact-stories/impact-stories-slice'
import { servicesApi } from './features/home/services/services-api'
import { successRatesApi } from './features/home/success-rates/success-rates-api'
import { storyApi } from './features/story/success-stories-api'

export const store = configureStore({
  reducer: {
    impactStories: impactStoriesSlice,
    [storyApi.reducerPath]: storyApi.reducer,
    [impactStoriesApi.reducerPath]: impactStoriesApi.reducer,
    [blogsApi.reducerPath]: blogsApi.reducer,
    [servicesApi.reducerPath]: servicesApi.reducer,
    [successRatesApi.reducerPath]: successRatesApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(
      impactStoriesApi.middleware,
      storyApi.middleware,
      blogsApi.middleware,
      servicesApi.middleware,
      successRatesApi.middleware
    ),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
