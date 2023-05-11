import { Blog } from '@/types/blog/blog'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const addNewBlogApi = createApi({
  reducerPath: 'blog/add',
  baseQuery: fetchBaseQuery({ baseUrl: 'http://localhost:3004' }),
  endpoints(builder) {
    return {
      addBlog: builder.mutation({
        query: (body: Blog) => {
          return { url: '/blogs', method: 'POST', body }
        },
      }),
    }
  },
})

export const { useAddBlogMutation } = addNewBlogApi
