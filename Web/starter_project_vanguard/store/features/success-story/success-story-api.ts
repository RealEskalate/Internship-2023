import { SuccessStory } from '@/types/success-story'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
const API_BASE_URL = 'http://localhost:3004'
export const successStoryApi = createApi({
  reducerPath: 'success-story/api',
  baseQuery: fetchBaseQuery({
    baseUrl: API_BASE_URL,
  }),
  endpoints(builder) {
    return {
      fetchSuccessStory: builder.query<SuccessStory[], void>({
        query: () => '/success-story',
      }),
    }
  },
})

export const { useFetchSuccessStoryQuery } = successStoryApi
