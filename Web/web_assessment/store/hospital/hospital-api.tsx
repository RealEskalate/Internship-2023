import { Welcome } from '../../types/Hospital';
import { createApi, fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const baseUrl = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1';



interface GetDoctorByIdParams {
  id: string;
}

export const hospitalApi = createApi({
  reducerPath: 'hospitalApi',
  baseQuery: fetchBaseQuery({ baseUrl }),
  endpoints: (builder) => ({
    getHospitals: builder.query<Welcome, void>({
      query: (params) => ({
        url: 'search?institutions=false&articles=false',
        method: 'POST',
        body: params,
      }),
      
    }),
    // getDoctorById: builder.query<Doctor, string>({
    //   query: (id) => /users/doctorProfile/${id},
    // }),
  }),
});

export const { useGetHospitalsQuery } = hospitalApi;