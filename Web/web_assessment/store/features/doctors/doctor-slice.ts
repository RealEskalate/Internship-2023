// in this slice I will store the Id of doctor which is string

import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface DoctorState {
    doctorId: string;
}

const initialState: DoctorState = {
    doctorId: "",
};  

const doctorSlice = createSlice({
    name: "doctor",
    initialState,
    reducers: {
        setDoctorId(state, action: PayloadAction<string>) {
            state.doctorId = action.payload;
        }
    }
});

export const { setDoctorId } = doctorSlice.actions;
export default doctorSlice.reducer;
