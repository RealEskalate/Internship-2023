import { ProblemItem, Project, Session, SolutionItem } from '@/types/about'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const aboutApi = createApi({
  reducerPath: 'about',
  baseQuery: fetchBaseQuery({ baseUrl: '/api/about/' }),
  endpoints: (build) => ({
    getProjects: build.query<Project[], void>({
      query: () => 'projects',
    }),
    getSessions: build.query<Session[], void>({
      query: () => 'sessions',
    }),
    getProblemItems: build.query<ProblemItem[], void>({
      query: () => 'problem-items',
    }),
    getSolutionItems: build.query<SolutionItem[], void>({
      query: () => 'solution-items',
    }),
  }),
})

export const {
  useGetProblemItemsQuery,
  useGetProjectsQuery,
  useGetSessionsQuery,
  useGetSolutionItemsQuery,
} = aboutApi
