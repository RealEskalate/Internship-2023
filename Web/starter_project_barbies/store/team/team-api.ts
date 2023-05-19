import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import {TeamMember} from "@/types/team";

const BASE_URL = process.env.NEXT_PUBLIC_BASE_URL

export const teamApi = createApi({
    baseQuery: fetchBaseQuery({baseUrl: BASE_URL}),
    endpoints: (builder) => ({
        getTeamMembers: builder.query<TeamMember[], void>({
            query: () => '/team-members',
        }),
    }),
});

export const {useGetTeamMembersQuery} = teamApi;
