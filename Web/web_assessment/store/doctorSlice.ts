import { createSlice, createAsyncThunk } from "@reduxjs/toolkit";
import axios from "axios";

interface Doctor {
  id: string;
  name: string;
  specialty: string;
  // Add other doctor properties
}

interface DoctorsState {
  doctors: Doctor[];
  selectedDoctor: Doctor | null;
  // Add other state properties
}

const initialState: DoctorsState = {
  doctors: [],
  selectedDoctor: null,
  // Initialize other state properties
};

export const fetchDoctors = createAsyncThunk(
  "doctors/fetchDoctors",
  async () => {
    const response = await axios.post(
      "https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/search?institutions=false&from=1&size=8"
    );
    return response.data;
  }
);

export const fetchDoctorProfile = createAsyncThunk(
  "doctors/fetchDoctorProfile",
  async (id: string) => {
    const response = await axios.get(
      `https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/users/doctorProfile/${id}`
    );
    return response.data;
  }
);

export const searchDoctors = createAsyncThunk(
  "doctors/searchDoctors",
  async (keyword: string) => {
    const response = await axios.post(
      `https://hakimhub-api-dev-wtupbmwpnq-uc.a.run.app/api/v1/search?keyword=${keyword}&institutions=false&articles=False`
    );
    return response.data;
  }
);

const doctorsSlice = createSlice({
  name: "doctors",
  initialState,
  reducers: {},
  extraReducers: (builder) => {
    builder.addCase(fetchDoctors.fulfilled, (state, action) => {
      state.doctors = action.payload;
    });
    builder.addCase(fetchDoctorProfile.fulfilled, (state, action) => {
      state.selectedDoctor = action.payload;
    });
    builder.addCase(searchDoctors.fulfilled, (state, action) => {
      state.doctors = action.payload;
    });
  },
});

export default doctorsSlice.reducer;
