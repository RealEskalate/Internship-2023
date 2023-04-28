export interface Story {
    heading: string, 
    paragraph: string
  }
  
export interface SuccessStory {
    personName: string,
    imageURL: string,
    role: string,
    location: string,
    
    story: Story[]
}