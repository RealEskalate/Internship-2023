import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const baseUrl = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/search?institutions=false&articles=False'

export const doctorsApi = createApi({
  reducerPath: 'doctors',
  baseQuery: fetchBaseQuery({ baseUrl }),
  endpoints: (builder) => ({
    getDoctors: builder.query({
      query: () => ({
        url: '/',
        method: 'POST',
        body: { institutions: false, articles: false },
      }),
    }),
    postDoctors: builder.mutation({
      query: (data) => ({
        url: '/',
        method: 'POST',
        body: data,
      }),
    }),
  }),
});

export const { useGetDoctorsQuery, usePostDoctorsMutation } = doctorsApi;
