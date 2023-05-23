import { backend_url } from '@/config'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const doctorsApi = createApi({
  reducerPath: 'doctorsApi',
  baseQuery: fetchBaseQuery({ 
    baseUrl: backend_url}),
  endpoints: (builder) => ({
    getDoctors: builder.query<any, string>({
      query: (keyword) => ({
          url: `/search?keyword=${keyword}&institutions=false&articles=False`,
          method: 'POST'
      }),
    }),
  }),
})

export const { useGetDoctorsQuery } = doctorsApi
