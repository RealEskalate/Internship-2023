import { Blog, UpdateBlog } from '@/types/blog';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const BASE_URL = process.env.NEXT_PUBLIC_BASE_URL

// Define a service using API routes
export const blogApi = createApi({
  reducerPath: 'blogApi',
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL, mode: 'cors' }),
  tagTypes:['Blog'],
  endpoints: (builder) => ({
    getBlogs: builder.query<Blog[], void>({
      query: () => '/blogs',
      providesTags:['Blog']
    }),
    getBlogByID: builder.query<Blog, string>({
      query: (id) => `/blogs/${id}`,
      providesTags:(result, meta, args) => [{id: args, type:'Blog'}]
    }),
    addBlog: builder.mutation<Blog, Partial<Blog>>({
      query: (blog) => ({
        url: '/blogs',
        method: 'POST',
        body: blog,
      }),
      invalidatesTags:['Blog']
    }),
    getBlogsByUserID: builder.query<Blog[], string>({
      query: (userID) => `/blogs?userID=${userID}`,
      providesTags:(result, meta, args) => [{userId: args, type:'Blog'}]
    }),
    updateBlogById: builder.mutation<Blog, {id:string, blog:UpdateBlog, userId:string}>({
      query: ({id, blog}) => ({
          url:`/blogs/${id}`,
          method:'PATCH',
          body:blog
      }),
      invalidatesTags:(result, meta, args) => ['Blog',{userId:args.userId, type:'Blog'}, {id:args.id, type:'Blog'}]
    })
  }),
})

// Export hooks for usage
export const { useGetBlogsQuery, useGetBlogByIDQuery, useAddBlogMutation,useGetBlogsByUserIDQuery, useUpdateBlogByIdMutation } = blogApi
