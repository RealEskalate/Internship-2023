import { DoctorResponse, Doctor } from '@/types/doctor';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const BASE_URL = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1';

export const doctorsApi = createApi({
  reducerPath: 'doctorsApi',
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL }),
  endpoints: (builder) => ({
    getAllDoctors: builder.query<DoctorResponse, void>({
      query: () => ({
        url: '/search?institutions=false&articles=False',
        method: 'POST'
      }),
    }),
    getDoctorById: builder.query<Doctor, string>({
      query: (id) => `/users/doctorProfile/${id}`,
    }),
  }),
});

export const { useGetAllDoctorsQuery, useGetDoctorByIdQuery } = doctorsApi;