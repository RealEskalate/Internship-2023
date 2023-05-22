import { User } from '@/types/profile'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
const baseUrl = 'http://localhost:3004/'
console.log(baseUrl)

export const usersApi = createApi({
  reducerPath: 'usersApi',
  baseQuery: fetchBaseQuery({ baseUrl }),
  tagTypes: ['User'],
  endpoints: (builder) => ({
    fetchUser: builder.query<User, void>({
      query: () => 'profile',
      providesTags: ['User'],
    }),
    updateUser: builder.mutation<User, User>({
      query: (user) => ({
        url: `profile`,
        method: 'PATCH',
        body: user,
      }),
      invalidatesTags: ['User'],
    }),
  }),
})

export const { useFetchUserQuery, useUpdateUserMutation } = usersApi
