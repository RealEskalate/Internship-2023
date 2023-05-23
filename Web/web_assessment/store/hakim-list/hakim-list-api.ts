import {createApi, fetchBaseQuery} from "@reduxjs/toolkit/query/react"
import {Doctor, DoctorList} from "../../type/hakim"
const API_BASE_URL = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1"
export const hakimList = createApi({
    reducerPath:'homeList',
    baseQuery:fetchBaseQuery({baseUrl:API_BASE_URL}),
    endpoints:(builder) => ({
        getDoctors:builder.query<DoctorList, void>({
            query: () => ({
                url: '/search?institutions=false&articles=False',
                method: 'POST',
              }),
        }),
        getDoctorById: builder.query<Doctor, string>({
            query: (id) => `/users/doctorProfile/${id} `,
          }),
        searchDoctor: builder.query<DoctorList, string>({
            query: (name) => ({
                url:`/search?keyword=${name}&institutions=false&articles=False`,
                method:"POST"

            }),
          }),
    })

})
export const {
    useGetDoctorsQuery,
    useGetDoctorByIdQuery,
    useSearchDoctorQuery
  } = hakimList