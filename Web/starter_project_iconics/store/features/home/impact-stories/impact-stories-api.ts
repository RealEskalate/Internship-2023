import { backend_url } from '@/config'
import { ImpactStory } from '@/types/home/impact-story'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const impactStoriesApi = createApi({
  reducerPath: 'impact-stories',
  baseQuery: fetchBaseQuery({
    baseUrl: `${backend_url}`,
  }),
  endpoints: (builder) => ({
    getStories: builder.query<ImpactStory[], void>({
      query: () => '/home/impact-stories',
    }),
  }),
})

export const { useGetStoriesQuery } = impactStoriesApi
