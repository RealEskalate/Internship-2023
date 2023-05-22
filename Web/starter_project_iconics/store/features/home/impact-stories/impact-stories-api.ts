import { backend_url } from '@/config'
import { ImpactStory } from '@/types/home/impact-story'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const impactStoriesApi = createApi({
  reducerPath: 'impact-stories',
  baseQuery: fetchBaseQuery({
    baseUrl: `${backend_url}/home`,
  }),
  endpoints: (builder) => ({
    getStories: builder.query<ImpactStory[], void>({
      query: () => '/impact-stories',
    }),
  }),
})

export const { useGetStoriesQuery } = impactStoriesApi
