import { configureStore } from '@reduxjs/toolkit';
import { doctorsApi} from './features/doctor/doctor-api'
// import doctorsReducer from './doctorsSlice';

export const store = configureStore({
  reducer: {
    [doctorsApi.reducerPath] : doctorsApi.reducer
  },
  middleware: (getDefaultMiddleware) =>
  getDefaultMiddleware().concat(
    doctorsApi.middleware,
  ),
});

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch