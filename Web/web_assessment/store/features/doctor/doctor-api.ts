import { Welcome } from '@/types/doctor/doctor'

const BASE_URL = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1'

import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

export const doctorsApi = createApi({
  reducerPath: "doctorsApi",
  baseQuery: fetchBaseQuery({  baseUrl: 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1',
  method: 'POST', 
  headers: {
    'Content-Type': 'application/json',
  },
}),
  endpoints: (builder) => ({
    getDoctors: builder.query<any,void>({
      query: () => '/search?institutions=false&articles=False',
    }),
    getDoctorProfile: builder.query({
      query: (id) => `users/doctorProfile/${id}`,
    }),
  }),
});

export const { useGetDoctorsQuery, useGetDoctorProfileQuery } = doctorsApi;

export default doctorsApi.reducer;