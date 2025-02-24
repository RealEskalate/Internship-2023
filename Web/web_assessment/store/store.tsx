import { configureStore } from '@reduxjs/toolkit';
import { doctorsReducer } from '../api-slice/doctors-api';
import { doctorsApi } from '../api-slice/doctors-api';

export const store = configureStore({
  reducer: {
    doctors: doctorsReducer,
    [doctorsApi.reducerPath]: doctorsApi.reducer,
  },
  middleware: (getDefaultMiddleware) => getDefaultMiddleware().concat(doctorsApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;
