import { createSlice, PayloadAction } from "@reduxjs/toolkit";

interface stateType {
    numberOfItems: number,
    searchKeyword: string | undefined
}

const initialState: stateType = {
    numberOfItems: 20,
    searchKeyword: undefined
}

const jokesSlice = createSlice(
    {
        name: "jokes",
        initialState,
        reducers: {
            setNumberOfItems: (state, action: PayloadAction<number>) => {
                state.numberOfItems = action.payload;
            },
            setSearchKeyword: (state, action: PayloadAction<string | undefined>) => {
                state.searchKeyword = action.payload;
            }
        }
    }
)
export const {setNumberOfItems, setSearchKeyword} = jokesSlice.actions;
//export const selectState = (state : stateType) => state;
export default jokesSlice.reducer;
