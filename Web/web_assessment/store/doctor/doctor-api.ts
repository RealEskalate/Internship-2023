import { createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react'

const BASE_URL = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/'

export const doctorApi = createApi({
    reducerPath:'doctor',
    baseQuery: fetchBaseQuery({baseUrl:BASE_URL}),
    endpoints: (builder)=> ({
        fetchDoctor: builder.query({
            query:(id) => `/users/doctorProfile/${id}`
        }),
        fetchDoctors: builder.mutation<any, void>({
            query: () => ({
                url:'search?institutions=false&articles=False',
                method:'POST'
            })
        }),
        fetchDoctorWithPagination: builder.mutation<any, number>({
            query:(page) => ({
                url:`search?institutions=false&from=${page}&size=8`,
                method:'POST'
            })
        }),
        searchDoctors: builder.mutation<any, string>({
            query:(keyword) => ({
                url:`search?keyword=${keyword}&institutions=false&articles=False`,
                method:'POST'
            })
        })
    }),

})

export const { useFetchDoctorsMutation, useFetchDoctorQuery, useFetchDoctorWithPaginationMutation, useSearchDoctorsMutation } = doctorApi