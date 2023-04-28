export interface Story {
  heading: string
  paragraph: string
}

export interface SuccessStory {
  personName: string
  imgURL: string
  role: string
  location: string
  story: Story[]
}

