import { configureStore } from '@reduxjs/toolkit'
import { hakimList } from './hakim-list/hakim-list-api'

export const store = configureStore({
  reducer: {
    [hakimList.reducerPath] : hakimList.reducer
    
    
  },

  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(hakimList.middleware),
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch