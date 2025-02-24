// doctorsApi.ts

import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const doctorsApi = createApi({
  baseQuery: fetchBaseQuery({
    baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app',
  }),
  endpoints: (builder) => ({
    fetchDoctors: builder.mutation<Doctor[], any>({
      query: (data) => ({
        url: '/api/v1/search?institutions=false&articles=false',
        method: 'POST',
        body: data,
      }),
    }),
  }),
});

export const { useFetchDoctorsMutation } = doctorsApi;
export const doctorsReducer = doctorsApi.reducer;
