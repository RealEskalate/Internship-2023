import React from 'react';
import { Provider } from 'react-redux';
import { configureStore } from '@reduxjs/toolkit';
import { createWrapper } from 'next-redux-wrapper';
import { doctorsApi, doctorsReducer } from '../lib/doctors-api';
import { AppProps } from 'next/app';

const store = configureStore({
  reducer: {
    [doctorsApi.reducerPath]: doctorsReducer,
  },
  middleware: (getDefaultMiddleware) =>
    getDefaultMiddleware().concat(doctorsApi.middleware),
});

const makeStore = () => store;

const wrapper = createWrapper(makeStore);

const MyApp = ({ Component, pageProps }: AppProps) => (
  <Provider store={store}>
    <Component {...pageProps} />
  </Provider>
);

export default wrapper.withRedux(MyApp);
