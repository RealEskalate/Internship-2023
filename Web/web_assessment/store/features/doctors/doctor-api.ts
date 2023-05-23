import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";
import { Doctor, DoctorListss } from "@/types/doctor/doctor";

// Fetch Doctor Profile

// https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/users/doctorProfile/:id
// Method - GET

export const doctorApi = createApi({
  reducerPath: "doctorApi",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app",
  }),
  endpoints: (builder) => ({
    getDoctors: builder.query({
      query: (name) => ({
        url: "/api/v1/search?institutions=false&articles=False",
        method: "POST",
        body: {
          name,
          institutions: false,
          articles: false,
        },
      }),
    }),
    fetchDoctorProfile: builder.query({
      query: (id) => ({
        url: `/api/v1/users/doctorProfile/62b959bf23006348f0f44b53`,
        method: "GET",
      }),
    }),
  }),
});

export const { useGetDoctorsQuery,useFetchDoctorProfileQuery } = doctorApi;
