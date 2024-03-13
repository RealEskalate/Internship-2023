import { HospitalResponse,Hospital } from '@/types/hospital';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const BASE_URL = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1';

export const hospitalsApi = createApi({
  reducerPath: 'hospitalsApi',
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
  endpoints: (builder) => ({
    getHospitals: builder.query<HospitalResponse, void>({
      query: () => ({
        url: '/search?institutions=true&articles=False&doctors=false',
        method: 'POST'
      }),
    }),
    getHospitalById: builder.query<Hospital, string>({
      query: (id) => `/users/doctorProfile/${id}`,
    }),
    searchHospital: builder.query<HospitalResponse, string>({
      query: (query) => ({
        url: `/search?keyword=${query}&institutions=true&articles=False&doctors=false`,
        method: 'POST'
      })
    })
  }),
});

export const { useGetHospitalsQuery, useGetHospitalByIdQuery, useSearchHospitalQuery } = hospitalsApi;