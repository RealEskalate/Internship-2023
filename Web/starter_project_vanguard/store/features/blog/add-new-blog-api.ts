import { Blog } from '@/types/blog/blog'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const addNewBlogApi = createApi({
  reducerPath: 'blog/add',
  baseQuery: fetchBaseQuery({ baseUrl: 'http://localhost:3000/api' }),
  endpoints(builder) {
    return {
      addBlog: builder.mutation({
        query: (body: Blog) => ({
          headers: {
            'Accept-Encoding': 'gzip, deflate',
            'Content-Type': 'application/json',
          },
          url: '/blogs',
          method: 'POST',
          body: body,
        }),
      }),
    }
  },
})

export const { useAddBlogMutation } = addNewBlogApi
