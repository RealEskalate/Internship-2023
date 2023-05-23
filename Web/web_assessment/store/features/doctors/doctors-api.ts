
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const doctorsApi = createApi({
  reducerPath: "doctorsApi",
  baseQuery: fetchBaseQuery({  baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1',
   // Set the default request method to POST
  headers: {
    'Content-Type': 'application/json',
  },
}),
  endpoints: (builder) => ({
    getDoctors: builder.query<any, string>({
      query: (keyword) =>({ url:"search?institutions=false&articles=False", method: 'POST',}),
    }),
    getDoctorProfile: builder.query<any, string>({
      query: (id) => `users/doctorProfile/${id}`,
      
    }),
    searchDoctors: builder.query<any, string>({
      query: (keyword) =>({ url:`search?keyword=${keyword}institutions=false&articles=False`, method:'POST'}),
    }),
  }),
});

export const { useGetDoctorsQuery, useGetDoctorProfileQuery, useSearchDoctorsQuery } = doctorsApi;