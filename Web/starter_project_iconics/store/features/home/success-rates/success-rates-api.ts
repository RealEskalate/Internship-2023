import { backend_url } from '@/config'
import { Success } from '@/types/home/success-rate'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const successRatesApi = createApi({
  reducerPath: 'success-rates',
  baseQuery: fetchBaseQuery({
    baseUrl: `${backend_url}`,
  }),
  endpoints: (builder) => ({
    getSuccessRates: builder.query<Success[], void>({
      query: () => '/home/success-rates',
    }),
  }),
})

export const { useGetSuccessRatesQuery } = successRatesApi
