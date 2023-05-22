import { createSlice } from '@reduxjs/toolkit'

interface Tags {
  allTags: string[]
  selectedTags: string[]
}
const initialState: Tags = {
  selectedTags: [],
  allTags: [],
}

export const tagsSlice = createSlice({
  name: 'tags',
  initialState,
  reducers: {
    setAllTags: (state, action) => {
      state.allTags = action.payload
    },
    setSelectedTags: (state, action) => {
      const tag = action.payload

      if (state.selectedTags.includes(tag)) {
        // Remove the tag from the selected tags
        state.selectedTags = state.selectedTags.filter(
          (selectedTag) => selectedTag !== tag
        )
      } else {
        // Add the tag to the selected tags
        state.selectedTags.push(tag)
      }
    },
  },
})

export const { setAllTags, setSelectedTags } = tagsSlice.actions

export default tagsSlice.reducer
