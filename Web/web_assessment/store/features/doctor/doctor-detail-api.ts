import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
const baseUrl = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/users/doctorProfile/";

export const doctorDetailApi = createApi({
  reducerPath: "doctors-detail",
  baseQuery: fetchBaseQuery({ baseUrl }),
  endpoints: (builder) => ({
    getDoctorDetail: builder.query({
      query: (id) => ({
        url: `/${id}`,
        method: "GET",
      }),
    }),
  }),
});

export const {useGetDoctorDetailQuery} = doctorDetailApi
