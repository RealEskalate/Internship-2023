import { Partner } from '@/types/story';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const BASE_URL = process.env.NEXT_PUBLIC_BASE_URL

export const partnersApi = createApi({
  reducerPath: 'partnersApi',
  baseQuery: fetchBaseQuery({ baseUrl: BASE_URL, mode: 'cors' }),
  endpoints: (builder) => ({
    getCompany: builder.query<Partner[], void>({
      query: () => '/company',
    }),
    
  }),
})

export const { useGetCompanyQuery } = partnersApi