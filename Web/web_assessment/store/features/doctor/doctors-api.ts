import {createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const baseUrl = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app'



export const doctorsApi = createApi({
    reducerPath: 'doctors',
    baseQuery: fetchBaseQuery({ baseUrl }),
    endpoints: (builder) => ({
        postDoctors: builder.query({
            query: (data) => ({
                url: `/api/v1/search?keyword=${data}&institutions=false&articles=False/doctors`,
                method: "POST",
               
            })
        })
    })
})

export const { usePostDoctorsQuery } = doctorsApi