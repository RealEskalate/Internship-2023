import {
  combineReducers,
  configureStore,
} from '@reduxjs/toolkit'

import {userApi as api} from '@/pages/api/profile'

const rootReducer = combineReducers({
  [api.reducerPath]: api.reducer,
})

const store = configureStore({
  reducer: rootReducer,
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(api.middleware),
})

export default store
