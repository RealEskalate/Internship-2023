import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const doctorsApi = createApi({
  reducerPath: "doctorsApi",
  baseQuery: fetchBaseQuery({  baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1',
  method: 'GET', // Set the default request method to POST
  headers: {
    'Content-Type': 'application/json',
  },
}),
  endpoints: (builder) => ({
    searchDoctors: builder.query<any, string>({
      query: (keyword) => ({
        url: `search?keyword=${keyword}&institutions=false&articles=false`,
        method: 'POST',
        body: { keyword, institutions: false, articles: false },
      }),
      
    }),
    getDoctorProfile: builder.query<any, string>({
      query: (id) => `users/doctorProfile/${id}`,
      
      
      
    }),
  }),
});

export const { useSearchDoctorsQuery, useGetDoctorProfileQuery } = doctorsApi;
