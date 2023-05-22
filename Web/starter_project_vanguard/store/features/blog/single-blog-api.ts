import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { Blog } from "@/types/blog/blog";

const API_BASE_URL = 'http://localhost:3004';
export const singleBlogApi = createApi({
  reducerPath: "singleBlogApi",
  baseQuery: fetchBaseQuery({ baseUrl: API_BASE_URL }),
  endpoints: (builder) => ({
    getSingleBlog: builder.query<Blog, string>({
      query: (id) => `/blogs/${id}`,
    }),
    
  }),
});

export const { useGetSingleBlogQuery } = singleBlogApi;