import { Story } from './../../types/story';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const BASE_URL = process.env.NEXT_PUBLIC_BASE_URL

export const storyApi = createApi({
  reducerPath: 'storyApi',
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL, mode: 'cors' }),
  endpoints: (builder) => ({
    getStories: builder.query<Story[], void>({
      query: () => '/story',
    }),
    
  }),
})

export const { useGetStoriesQuery } = storyApi