import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { SuccessStory } from '../../types/success-story'

export const apiSlice = createApi({
  reducerPath: 'success-story/api',
  baseQuery: fetchBaseQuery({
    baseUrl: 'http://localhost:3004',
  }),
  endpoints(builder) {
    return {
      fetchSuccessStory: builder.query<SuccessStory[], void>({
        query: () => '/success-story',
      }),
    }
  },
})

export const { useFetchSuccessStoryQuery } = apiSlice
