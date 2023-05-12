import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { User } from '@/types/profile'

export const userApi = createApi({
  reducerPath: 'usersApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'http://localhost:3004' }),
  endpoints: (builder) => ({
    fetchUser: builder.query<User, void>({
      query: () => '/profile',
    }),
    updateUser: builder.mutation<User, User>({
      query: (user) => ({
        url: `/profile`,
        method: 'PUT',
        body: user,
      }),

    }),
  }),
})

export const { useFetchUserQuery, useUpdateUserMutation } = userApi
