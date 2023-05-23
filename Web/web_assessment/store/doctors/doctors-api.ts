import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';
import {Doctor, DoctorDto} from "@/types/doctor";

const BASE_URL = process.env.NEXT_PUBLIC_BASE_URL

export const doctorsApi = createApi({
    baseQuery: fetchBaseQuery({baseUrl: BASE_URL}),
    endpoints: (builder) => ({
        getDoctors: builder.mutation<DoctorDto, void>({
            query: () => ({
                url: 'search?institutions=false&articles=False',
                method: 'POST',
            }),
        }),
        search: builder.mutation<DoctorDto, string>({
            query: (keyword) => ({
                url: `search?keyword=${keyword}&institutions=false&articles=false`,
                method: 'POST'
            })
        }),
        fetchDoctorDetails: builder.mutation<Doctor, string>({
            query: (id) => ({
                url: `/users/doctorProfile/${id}`,
                method: 'GET'
            })
        }),
    }),

});

export const {useGetDoctorsMutation, useSearchMutation, useFetchDoctorDetailsMutation} = doctorsApi;
