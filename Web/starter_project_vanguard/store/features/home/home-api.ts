import { Activity } from '@/types/home/Activity'
import { SuccessModel } from '@/types/home/SuccessModel'
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
    getSuccessRates: builder.query<SuccessModel[], void>({
      query: () => '/success-rates',
    }),
  }),
})

export const { useGetAllActivitiesQuery, useGetSuccessRatesQuery } = homeApi
