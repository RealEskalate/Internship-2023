import { IA2SVSession } from '@/types/about/a2sv-session'
import { Project } from '@/types/about/project'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const baseUrl = 'http://localhost:3004/'

export const aboutApi = createApi({
  reducerPath: 'about',
  baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
  endpoints: (build) => ({
    getA2SVSessions: build.query<IA2SVSession[], void>({
      query: () => 'a2sv-sessions',
    }),
    getSocialProjects: build.query<Project[], void>({
      query: () => 'social-projects',
    }),
  }),
})

export const { useGetA2SVSessionsQuery, useGetSocialProjectsQuery } = aboutApi
