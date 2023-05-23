import { configureStore } from "@reduxjs/toolkit";
import doctorReducer from "./doctor-slices";

const store = configureStore({
  reducer: {
    doctors: doctorReducer,
  },
});

export type RootState = ReturnType<typeof store.getState>;

export default store;
