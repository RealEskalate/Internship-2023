// import { Welcome } from '@/types/doctor/doctor'

const BASE_URL = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1'

import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const doctorsApi = createApi({
  reducerPath: "doctorsApi",
  baseQuery: fetchBaseQuery({  baseUrl: BASE_URL,
  method : 'GET',
  headers: {
    'Content-Type': 'application/json',
  },
}),
  endpoints: (builder) => ({
    getDoctors: builder.query({
      query: (keyword) =>({ url:"search?institutions=false&articles=False", method: 'POST',}),
    }),
    getDoctorProfile: builder.query<any, string>({
      query: (id) => `users/doctorProfile/${id}`,
      
    }),
    searchDoctors: builder.query({
      query: (keyword:string) =>({ url:`search?keyword=${keyword}institutions=false&articles=False`, method:'POST'}),
    }),
  }),
});

export const { useGetDoctorsQuery, useGetDoctorProfileQuery, useSearchDoctorsQuery } = doctorsApi;