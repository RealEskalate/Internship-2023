import { backend_url } from '@/config'
import { Blog } from '@/types/blog'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const blogApi = createApi({
  reducerPath: 'blog',
  baseQuery: fetchBaseQuery({ baseUrl: backend_url }),
  endpoints: (builder) => ({
    getBlogs: builder.query<Blog[], void>({
      query: () => 'blogs',
    }),
  }),
})

export const { useGetBlogsQuery } = blogApi
