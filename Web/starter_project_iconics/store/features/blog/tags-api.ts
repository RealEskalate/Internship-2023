import { backend_url } from '@/config'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const tagsApi = createApi({
  reducerPath: 'tags',
  baseQuery: fetchBaseQuery({ baseUrl: backend_url }),
  endpoints: (builder) => ({
    getTags: builder.query<string[], void>({
      query: () => '/tags',
    }),
  }),
})

// export default blogApiSlice
export const { useGetTagsQuery } = tagsApi
