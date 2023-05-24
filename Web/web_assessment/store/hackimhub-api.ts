import { DoctorDetail } from "@/types/doctor-detail";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const baseUrl = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/";

export const api = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
  endpoints: (builder) => ({
    fetchDoctors: builder.query<{ data: DoctorDetail[] }, string>({
      query: (keyword) => ({
        url: `search?institutions=false&articles=false&keyword=${keyword}`,
        method: "POST",
      }),
    }),
    fetchDoctorsWithPagination: builder.query<
      { data: DoctorDetail[] },
      { from: number; size: number }
    >({
      query: ({ from, size }) => ({
        url: `search?institutions=false&from=${from}&size=${size}`,
        method: "POST",
      }),
    }),
    fetchDoctorProfile: builder.query<DoctorDetail, string>({
      query: (id) => ({
        url: `users/doctorProfile/${id}`,
        method: "GET",
      }),
    }),
  }),
});

export const {
  useFetchDoctorsQuery,
  useFetchDoctorsWithPaginationQuery,
  useFetchDoctorProfileQuery,
} = api;
