import { Doctor } from '@/types/doctor';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const baseUrl = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1';

interface GetDoctorsParams {
  from: number;
  size: number;
}

interface GetDoctorByIdParams {
  id: string;
}

export const doctorsApi = createApi({
  reducerPath: 'doctorsApi',
  baseQuery: fetchBaseQuery({ baseUrl }),
  endpoints: (builder) => ({
    getDoctors: builder.query<Doctor[], GetDoctorsParams>({
      query: (params) => ({
        url: 'search?institutions=false&articles=false',
        method: 'POST',
        body: params,
      }),
      transformResponse: (response: { data: Doctor[] }) => response.data,
    }),
    getDoctorById: builder.query<Doctor, string>({
      query: (id) => `users/doctorProfile/${id}`,
      transformResponse: (response: { data: Doctor }) => response.data,
    }),
  }),
});

export const { useGetDoctorsQuery, useGetDoctorByIdQuery } = doctorsApi;
