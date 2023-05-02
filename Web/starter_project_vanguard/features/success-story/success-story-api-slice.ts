import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { SuccessStory } from '../../types/success-story'

const url = 'http://localhost:3004'
export const apiSlice = createApi({
  reducerPath: 'success-story/api',
  baseQuery: fetchBaseQuery({
    baseUrl: url,
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
