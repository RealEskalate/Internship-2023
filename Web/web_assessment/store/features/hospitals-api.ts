import {createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const baseUrl = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app'


export const hospitalsApi = createApi({
    reducerPath: 'doctors',
    baseQuery: fetchBaseQuery({ baseUrl }),
    endpoints: (builder) => ({
        postHospitals: builder.query({
            query: (data) => ({
                
                url: `/api/v1/search?keyword=${data}&institutions=true&articles=False&doctors=false/hospital`,
                method: "POST",
               
            })
        })
    })
})

export const { usePostHospitalsQuery } = hospitalsApi