import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
const url = 'http://localhost:3004'

export const getBlogs = createApi({
  reducerPath: 'blogsApi',
  baseQuery: fetchBaseQuery({ baseUrl: url }),
  endpoints: (builder) => ({
    getBlogs: builder.query({
      query: () => '/blogs',
    }),
  }),
})

export const { useGetBlogsQuery } = getBlogs
