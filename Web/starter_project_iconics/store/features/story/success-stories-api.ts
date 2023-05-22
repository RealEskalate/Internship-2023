import {createApi,fetchBaseQuery} from '@reduxjs/toolkit/query/react'
import { SuccessStory } from '../../../types/story/success-stories'

const API_BASE_URL = '/api';

export const storyApi = createApi({
    reducerPath: 'storiesApi',
    baseQuery: fetchBaseQuery({baseUrl: API_BASE_URL}),
    endpoints: (builder) => ({
        getStories: builder.query<SuccessStory[], void>({
            query: () => '/success-stories',
        }),
    }),
})

export const { useGetStoriesQuery} = storyApi