import { SuccessStory } from '@/types/success-story'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
const url = 'http://localhost:3000/api'
export const successStoryApi = createApi({
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

export const { useFetchSuccessStoryQuery } = successStoryApi
