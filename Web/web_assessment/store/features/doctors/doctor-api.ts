import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const doctorApi = createApi({
  reducerPath: 'doctorApi',
  baseQuery: fetchBaseQuery({ 
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1"}),
  endpoints: (builder) => ({
    getDoctor: builder.query<any, string>({
      query: (id) => ({
          url: `/users/doctorProfile/${id}`
      }),
    }),
  }),
})

export const { useGetDoctorQuery } = doctorApi