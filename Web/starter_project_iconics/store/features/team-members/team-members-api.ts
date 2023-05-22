import { backend_url } from '@/config'
import { TeamMember } from '@/types/teams'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

export const teamMembersApi = createApi({
    reducerPath: 'team-members',
    baseQuery: fetchBaseQuery({baseUrl: backend_url}),
    endpoints: builder => ({
        getTeamMembers: builder.query<TeamMember[], void>({
            query: () => '/team-members'
        })
    })
})

export const {useGetTeamMembersQuery} = teamMembersApi