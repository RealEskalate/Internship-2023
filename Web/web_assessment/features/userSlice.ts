import { Doctor } from '@/types/Doctor'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
const baseUrl = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1' 
export const userApi = createApi({
  reducerPath: 'usersApi',
  baseQuery: fetchBaseQuery({ baseUrl}),
  endpoints: (builder) => ({
    fetchUser: builder.mutation<Doctor[], void>({
      query: () => ({
        url: '/search?institutions=false&from=1&size=20',
        method: "POST"})
    }),  
  }),
})

export const { useFetchUserMutation } = userApi