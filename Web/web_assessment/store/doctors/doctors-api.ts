import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const BASE_URL = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/search';

export const doctorsApi = createApi({
  reducerPath: 'doctorsApi',
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
  endpoints: (builder) => ({
    getDoctors: builder.query({
      query: () => '?institutions=false&articles=False',
    }),
  }),
});