import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const doctorsApi = createApi({
  reducerPath: "doctorsApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1",
    // Set the default request method to POST
    headers: {
      "Content-Type": "application/json",
    },
  }),
  endpoints: (builder) => ({
    getDoctorProfile: builder.query<any, string>({
      query: (id) => `users/doctorProfile/${id}`,
    }),
    searchDoctors: builder.query<any, string>({
      query: (keyword: string) => ({
        url: `search?keyword=${keyword}&institutions=false&articles=False`,
        method: "POST",
      }),
    }),
  }),
});

export const { useGetDoctorProfileQuery, useSearchDoctorsQuery } = doctorsApi;
