import { configureStore } from '@reduxjs/toolkit'
import { companyApi } from './story/companies-api'
import { storyApi } from './story/story-api'

export const store = configureStore({
  reducer: {
    [storyApi.reducerPath]: storyApi.reducer,
    [companyApi.reducerPath]: companyApi.reducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(storyApi.middleware).concat(companyApi.middleware)
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
