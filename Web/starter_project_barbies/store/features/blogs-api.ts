import { Blog } from '@/types/blog'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const BASE_URL = 'http://localhost:5000/'

// Define a service using a base URL and expected endpoints
export const blogApi = createApi({
  reducerPath: 'blogApi',
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL, mode: 'cors' }),
  endpoints: (builder) => ({
    getBlogs: builder.query<Blog[], void>({
      query: () => '/blogs',
    }),
    getBlogByID: builder.query<Blog, string>({
      query: (id) => `/blogs/${id}`,
    }),
  }),
})

// Export hooks for usage
export const { useGetBlogsQuery, useGetBlogByIDQuery } = blogApi
