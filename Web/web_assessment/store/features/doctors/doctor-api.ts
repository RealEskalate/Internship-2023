import { backend_url } from '@/config'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const doctorApi = createApi({
  reducerPath: 'doctorApi',
  baseQuery: fetchBaseQuery({ 
    baseUrl: backend_url}),
  endpoints: (builder) => ({
    getDoctor: builder.query<any, string>({
      query: (id) => ({
          url: `/users/doctorProfile/${id}`
      }),
    }),
  }),
})

export const { useGetDoctorQuery } = doctorApi
