import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const baseUrl = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/users/doctorProfile';

export const doctorsDetailApi = createApi({
  reducerPath: 'doctordetail',
  baseQuery: fetchBaseQuery({ baseUrl }),
  endpoints: (builder) => ({
    getDoctorDetail: builder.query({
        query: (id) => ({
          url:  `/${id}`,
          method: 'GET',
        })

    }),


    postDoctorDetail: builder.mutation({
      query: (data) => ({
        url: '/users/doctorProfile',
        method: 'POST',
        body: data,
      }),
    }),
  }),
});

export const { useGetDoctorDetailQuery } = doctorsDetailApi;
