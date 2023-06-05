import {createApi, fetchBaseQuery} from '@reduxjs/toolkit/query/react';
import {HospitalResponse} from '../../type/HospitslList'
import {SearchResponse} from '../../type/search'


export const HospitalApi  = createApi ({
    reducerPath: 'HospitalApi',
    baseQuery : fetchBaseQuery ({
        baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/"
    }),
    endpoints: (builder) => ({
    getHospital: builder.mutation<HospitalResponse, void> ({
        query: () => ({
            url: 'api/v1/search?institutions=true&articles=False&doctors=false',
            method: 'POST',
        })
        }),
    search: builder.mutation<SearchResponse, string> ({
        query: (keyword:any) => ({
            url: `/api/v1/search?keyword=${keyword}&instiutions=false&articles=False`,
            method: "POST"
        })
    }) 
    })
}) 


export const{
    useGetHospitalMutation,
    useSearchMutation,
} = HospitalApi