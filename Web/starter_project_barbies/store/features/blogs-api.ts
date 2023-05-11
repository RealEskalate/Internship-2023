import { Blog } from '@/types/blog';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

// Define a service using API routes
export const blogApi = createApi({
  reducerPath: 'blogApi',
  baseQuery: fetchBaseQuery({ baseUrl: '/api', mode: 'cors' }),
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
