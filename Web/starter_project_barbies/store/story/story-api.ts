import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { Story } from '../../types/story'

export const storyApi = createApi({
  reducerPath: 'storyApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'http://localhost:5000' }),
  endpoints: (builder) => ({
    getStories: builder.query<Story[], void>({
      query: () => '/story',
    }),
  }),
})
export const { useGetStoriesQuery } = storyApi
