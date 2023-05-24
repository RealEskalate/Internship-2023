import { Doctor, Doctors } from '@/types/doctors'
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react'

const backend_url = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1'
export const doctorsApi = createApi({
    reducerPath: 'doctors',
    baseQuery: fetchBaseQuery({baseUrl: backend_url}),
    endpoints: builder => ({
        getDoctors: builder.query<Doctors, {}>({
            query: (params) => ({url:`/search`,params, method: 'POST'})
        }),
        getDoctor: builder.query<Doctor, string>({
            query: (id) => ({url:`/users/doctorProfile/${id}`, method: 'GET'})
        })
    })
})

export const {useGetDoctorsQuery, useGetDoctorQuery} = doctorsApi