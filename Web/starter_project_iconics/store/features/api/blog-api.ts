import { Blog } from '@/types/blog/blog'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const API_BASE_URL = 'http://localhost:3500'

export const blogApi = createApi({
  reducerPath: 'api/',
  baseQuery: fetchBaseQuery({ baseUrl: API_BASE_URL }),
  endpoints: (builder) => ({
    getBlogs: builder.query<Blog[], void>({
      query: () => 'blogs',
    }),
    getBlogById: builder.query<Blog, String>({
      query: (id) => `blog/${id}`,
    }),
  }),
})

export const { useGetBlogsQuery, useGetBlogByIdQuery } = blogApi
