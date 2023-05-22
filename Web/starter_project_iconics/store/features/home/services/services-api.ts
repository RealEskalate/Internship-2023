import { backend_url } from '@/config'
import { Service } from '@/types/home/service'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const servicesApi = createApi({
  reducerPath: 'services',
  baseQuery: fetchBaseQuery({
    baseUrl: `${backend_url}`,
  }),
  endpoints: (builder) => ({
    getServices: builder.query<Service[], void>({
      query: () => '/home/services',
    }),
  }),
})

export const { useGetServicesQuery } = servicesApi
