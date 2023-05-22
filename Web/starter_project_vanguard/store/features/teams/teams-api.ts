import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { TeamMember } from '@/types/teams'

export const teamsApi = createApi({
  reducerPath: 'teamsApi',
  baseQuery: fetchBaseQuery({
    baseUrl: 'http://localhost:3004',
  }),
  endpoints: (builder) => ({
    getTeamMembers: builder.query<TeamMember[], void>({
      query: () => '/team-members',
    }),
    
  }),
})

export const { useGetTeamMembersQuery } = teamsApi