// doctorsApi.js

import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const api = createApi({
  reducerPath: 'api',
  baseQuery: fetchBaseQuery({ baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1' }),
  endpoints: (builder) => ({
    postData: builder.mutation<any, any>({
      query: (data) => ({
        url: '/search',
        method: 'POST',
        body: data,
      }),
    }),
  }),
});

export const { usePostDataMutation } = api;



// import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

// export const doctorsApi = createApi({
//   baseQuery: fetchBaseQuery({
//     baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app',
//   }),
//   endpoints: (builder) => ({
//     fetchDoctors: builder.query({
//       query: () => '/api/v1/search?institutions=false&articles=false',
//     }),
//   }),
// });

// export const { useFetchDoctorsQuery } = doctorsApi;
// export const doctorsReducer = doctorsApi.reducer;
