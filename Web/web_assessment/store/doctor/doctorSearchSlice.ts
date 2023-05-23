import { createSlice } from '@reduxjs/toolkit';
import { createAsyncThunk } from '@reduxjs/toolkit';
import { fetchBaseQuery } from '@reduxjs/toolkit/query/react';

const searchDoctorsApi = createAsyncThunk('doctorSearch/searchDoctors', async (keyword) => {
  const baseUrl = 'https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/';
  const url = `${baseUrl}search?keyword=${keyword}&institutions=false&articles=false`;
  const response = await fetch(url, { method: 'POST' });
  const data = await response.json();
  return data;
});

const doctorSearchSlice = createSlice({
  name: 'doctorSearch',
  initialState: {
    keyword: '',
    doctors: [],
    loading: false,
    error: null,
  },
  reducers: {
    setKeyword: (state, action) => {
      state.keyword = action.payload;
    },
  },
  extraReducers: (builder) => {
    builder
      .addCase(searchDoctorsApi.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(searchDoctorsApi.fulfilled, (state, action) => {
        state.loading = false;
        state.doctors = action.payload;
      })
      .addCase(searchDoctorsApi.rejected, (state, action) => {
        state.loading = false;
        state.error = action.error.message;
      });
  },
});

export const { setKeyword } = doctorSearchSlice.actions;
export { searchDoctorsApi };
export default doctorSearchSlice.reducer;
