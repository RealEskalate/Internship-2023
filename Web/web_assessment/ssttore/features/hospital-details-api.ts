import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
const baseUrl = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/users/institutions/";


export const hospitalDetailsApi = createApi({
  reducerPath: "hospital-detail",
  baseQuery: fetchBaseQuery({ baseUrl }),
  endpoints: (builder) => ({
    getHospitalDetail: builder.query({
      query: (id) => ({
        url: `/${id}`,
        method: "GET",
      }),
    }),
  }),
});

export const {useGetHospitalDetailQuery} = hospitalDetailsApi
