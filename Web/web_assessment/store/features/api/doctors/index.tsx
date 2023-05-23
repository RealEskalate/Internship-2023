import { DoctorProfileResponse } from "@/types/doctor-profile";
import { DoctorsResponse } from "@/types/doctors";
import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export const doctorsApi = createApi({
  reducerPath: "doctors",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app",
  }),
  endpoints: (builder) => ({
    getDoctors: builder.mutation<DoctorsResponse, void>({
      query: () => ({
        url: "/api/v1/search?institutions=false&articles=False",
        method: "POST",
      }),
    }),
    getDoctorProfileById: builder.query<DoctorProfileResponse, string>({
      query: (id) => `/api/v1/users/doctorProfile/${id}`,
    }),

    search: builder.mutation<DoctorsResponse, void>({
      query: (keyword) => ({
        url: `/api/v1/search?keyword=${keyword}&institutions=false&articles=False`,
        method: "POST",
      }),
    }),
  }),
});

export const {
  useGetDoctorsMutation,
  useGetDoctorProfileByIdQuery,
  useSearchMutation,
} = doctorsApi;
