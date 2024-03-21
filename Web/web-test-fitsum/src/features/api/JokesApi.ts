import { createApi, fetchBaseQuery } from "@reduxjs/toolkit/query/react";

export interface JokeStructure {
  id: number;
  category: string;
  joke: string;
}
export interface FetchResultType {
  error: boolean,
  amount: number,
  jokes: JokeStructure[]
  message: string | undefined,
  causedBy: string | undefined,
}
export interface ApiParametres {
  amount: number;
  contains: string | undefined;
}

export const jokesApi = createApi({
  reducerPath: "api",
  baseQuery: fetchBaseQuery({
    baseUrl: "https://v2.jokeapi.dev",
  }),
  tagTypes: ["Jokes"],
  endpoints: (builder) => ({
    getJokes: builder.query<FetchResultType, ApiParametres>({
      query: (data) => ({
        url: `/joke/Any?type=single${
          data.contains ? `&contains=${data.contains}` : ""
        }&amount=${data.amount}`,
        method: "GET",
      }),
      providesTags: (result, error, id) => [{ type: "Jokes", id: "List" }],
    }),
  }),
});

export const { useGetJokesQuery } = jokesApi;
