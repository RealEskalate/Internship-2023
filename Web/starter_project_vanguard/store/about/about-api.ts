import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const aboutApi = createApi({
  reducerPath: 'about',
  baseQuery: fetchBaseQuery({ baseUrl: 'http://localhost:3004/' }),
  endpoints: (build) => ({
    getA2SVSessions: build.query<any, void>({
      query: () => 'a2sv-sessions',
    }),
    getSocialProjects: build.query<any, void>({
      query: () => 'social-projects',
    }),
  }),
})

export const { useGetA2SVSessionsQuery, useGetSocialProjectsQuery } = aboutApi
