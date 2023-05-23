import { createSlice, createAsyncThunk, PayloadAction } from "@reduxjs/toolkit";
import axios from "axios";

const API_BASE_URL = "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1";

interface Doctor {
  id: string;
  name: string;
  specialty: string;
  profilePicture: string;
  // Add other relevant properties
}

interface DoctorsState {
  list: Doctor[];
  selectedDoctor: Doctor | null;
  loading: boolean;
  error: string | null;
}

export const fetchDoctors: any = createAsyncThunk(
  "doctors/fetchDoctors",
  async () => {
    try {
      const response = await axios.post(
        `${API_BASE_URL}/search?institutions=false&articles=False`
      );
      return response.data;
    } catch (error) {
      throw Error("Failed to fetch doctors");
    }
  }
);

const initialState: DoctorsState = {
  list: [],
  selectedDoctor: null,
  loading: false,
  error: null,
};

const doctorSlice = createSlice({
  name: "doctors",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder
      .addCase(fetchDoctors.pending, (state) => {
        state.loading = true;
        state.error = null;
      })
      .addCase(
        fetchDoctors.fulfilled,
        (state, action: PayloadAction<Doctor[]>) => {
          state.loading = false;
          state.list = action.payload;
        }
      )
      .addCase(fetchDoctors.rejected, (state, action) => {
        state.loading = false;
        state.error = null;
      });
  },
});

export default doctorSlice.reducer;
