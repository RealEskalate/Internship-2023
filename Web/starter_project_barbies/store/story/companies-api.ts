import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'
import { Company } from '../../types/story'

export const companyApi = createApi({
  reducerPath: 'companyApi',
  baseQuery: fetchBaseQuery({ baseUrl: 'http://localhost:5000' }),
  endpoints: (builder) => ({
    getCompanies: builder.query<Company[], void>({
      query: () => '/company',
    }),
  }),
})
export const { useGetCompaniesQuery } = companyApi
