import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import { Doctor } from './../../types/doctor';

export const api = createApi({
  reducerPath: 'api',
  baseQuery: fetchBaseQuery({
    baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/'
  }),
  endpoints: (builder) => ({
    getDoctors: builder.query<Doctor[], void>({
      query: () => ({
        url: '/data',
        method: 'POST',
        params: { institutions: 'false', articles: 'false' },
      }),
    }),
  }),
});

export const { useGetDoctorsQuery } = api;

