import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
const API_BASE_URL = 'http://localhost:3001/api'

export const teamMembersApi = createApi({
    baseQuery: fetchBaseQuery({baseUrl: API_BASE_URL}),
    endpoints: builder => ({
        getTeamMembers: builder.query({
            query: () => '/team-members'
        })
    })
})

export const {useGetTeamMembersQuery} = teamMembersApi