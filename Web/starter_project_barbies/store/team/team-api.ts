import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import {TeamMember} from "@/types/team";

const api = createApi({
    baseQuery: fetchBaseQuery({baseUrl: 'http://localhost:5000'}),
    endpoints: (builder) => ({
        getTeamMembers: builder.query<TeamMember[], void>({
            query: () => '/team-members',
        }),
    }),
});

export const {useGetTeamMembersQuery} = api;
