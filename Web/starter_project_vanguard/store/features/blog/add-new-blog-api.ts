import { Blog } from '@/types/blog/blog'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const API_BASE_URL = 'http://localhost:3004'
export const addNewBlogApi = createApi({
  reducerPath: 'blog/add',
  baseQuery: fetchBaseQuery({ baseUrl: API_BASE_URL }),
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
