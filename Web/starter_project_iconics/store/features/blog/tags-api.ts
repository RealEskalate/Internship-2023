import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const API_BASE_URL = '/api'
export const tagsApi = createApi({
  reducerPath: 'tagsApi',
  baseQuery: fetchBaseQuery({ baseUrl: API_BASE_URL }),
  endpoints: (builder) => ({
    getTags: builder.query<string[], void>({
      query: () => '/tags',
    }),
  }),
})

// export default blogApiSlice
export const { useGetTagsQuery } = tagsApi
