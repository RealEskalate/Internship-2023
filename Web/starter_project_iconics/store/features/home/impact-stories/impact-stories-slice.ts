import { ImpactStory } from '@/types/home/impact-story'
import { PayloadAction, createSlice } from '@reduxjs/toolkit'

interface ImpactStoriesState {
  currentStory?: ImpactStory
}

const initialState: ImpactStoriesState = {
  currentStory: undefined,
}

export const impactStoriesSlice = createSlice({
  name: 'impact-stories',
  initialState,
  reducers: {
    selectStory: (state, action: PayloadAction<ImpactStory>) => {
      state.currentStory = action.payload
    },
  },
})

export const { selectStory } = impactStoriesSlice.actions

export default impactStoriesSlice.reducer
