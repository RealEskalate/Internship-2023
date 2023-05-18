import { configureStore } from '@reduxjs/toolkit'
import { impactStoriesApi } from './features/home/impact-stories/impact-stories-api'
import impactStoriesSlice from './features/home/impact-stories/impact-stories-slice'

export const store = configureStore({
  reducer: {
    impactStories: impactStoriesSlice,
    [impactStoriesApi.reducerPath]: impactStoriesApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(impactStoriesApi.middleware),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
