import { Activity } from '@/types/home/activity'
import { YearlySuccessRate } from '@/types/home/success-rate'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const homeApi = createApi({
  reducerPath: 'homeApi',
  baseQuery: fetchBaseQuery({
    baseUrl: 'http://localhost:3004',
  }),
  endpoints: (builder) => ({
    getAllActivities: builder.query<Activity[], void>({
      query: () => '/activities',
    }),
    getSuccessRates: builder.query<YearlySuccessRate[], void>({
      query: () => '/success-rates',
    }),
  }),
})

export const { useGetAllActivitiesQuery, useGetSuccessRatesQuery } = homeApi