import { configureStore } from '@reduxjs/toolkit';
import { api } from './doctor/doctorapi';


export const store = configureStore({
  reducer: {
    [api.reducerPath]: api.reducer,
    doctorSearch: doctorSearchReducer,
  },
  middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(api.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;





