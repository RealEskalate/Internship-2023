import { configureStore } from '@reduxjs/toolkit';
import { HospitalApi} from './features/api';

export const store = configureStore({
  reducer: {
    [HospitalApi.reducerPath]: HospitalApi.reducer,
  },
  middleware: (getDefaultMiddleware) => 
    getDefaultMiddleware().concat(HospitalApi.middleware),
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;