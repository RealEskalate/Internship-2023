import { Doctor } from '@/types/Doctor'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
const baseUrl = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1' 
export const userApi = createApi({
  reducerPath: 'usersApi',
  baseQuery: fetchBaseQuery({ baseUrl}),
  endpoints: (builder) => ({
    fetchUser: builder.query<any, void>({
      query: () => ({
        url: '/search?institutions=false&from=1&size=20',
        method: "POST"}),
    }), 
    fetchUserById: builder.query<Doctor, string>({
      query: (id) => ({
        url: `/users/doctorProfile/${id}`,
        method: "GET"
      }),
    }),
    fetchUserByKeyword: builder.query<any, string>({
      query: (keyword) => ({
        url: `/search?keyword=${keyword}&institutions=false&articles=False`,
        method: "POST"
      }),
    }),
  }),
  
})

export const { useFetchUserQuery, useFetchUserByIdQuery, useFetchUserByKeywordQuery } = userApi