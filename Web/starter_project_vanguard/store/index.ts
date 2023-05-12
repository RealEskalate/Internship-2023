import {
    combineReducers,
    configureStore,
  } from '@reduxjs/toolkit';
  import { userApi } from '@/pages/api/profile';
  
  const rootReducer = combineReducers({
    [userApi.reducerPath]: userApi.reducer,
  });
  
  const store = configureStore({
    reducer: rootReducer,
    middleware: (getDefaultMiddleware) =>
      getDefaultMiddleware().concat(userApi.middleware),
  });
  
  

  export default store;
  