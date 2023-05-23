import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

const baseUrl = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/";

export const doctorsApi = createApi({
  reducerPath: "doctorsApi",
  baseQuery: fetchBaseQuery({ baseUrl: baseUrl }),
  endpoints: (build) => ({
    getDoctorsData: build.mutation<UserData, string>({
      query: (keyword) => ({
        url: `/search?institutions=false&articles=False&keyword=${keyword}`,
        method: "POST",
      }),
    }),
    getSingleDoctor: build.query<UserData, string>({
      query: (id) => ({
        url: `/users/doctorProfile/${id}`,
        method: "GET",
      }),
    }),
  }),
});
export const { useGetDoctorsDataMutation, useGetSingleDoctorQuery } =
  doctorsApi;
