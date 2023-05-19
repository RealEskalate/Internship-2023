import { Blog } from '@/types/blog';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const BASE_URL = process.env.NEXT_PUBLIC_BASE_URL

// Define a service using API routes
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
    addBlog: builder.mutation<Blog, Partial<Blog>>({
      query: (blog) => ({
        url: '/blogs',
        method: 'POST',
        body: blog,
      }),
    }),
    getBlogsByUserID: builder.query<Blog[], string>({
      query: (userID) => `/blogs?userID=${userID}`,
    }),
  }),
})

// Export hooks for usage
export const { useGetBlogsQuery, useGetBlogByIDQuery, useAddBlogMutation,useGetBlogsByUserIDQuery } = blogApi
