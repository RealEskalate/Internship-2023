export interface User {
  id: number
  firstName: string
  lastName: string
  email: string
  photoUrl: string
}

export interface Blog {
  id: number
  title: string
  photoUrl: string
  description: string
  tags: string[]
  writter: User
  likes: number
  status: 'pending' | 'approved' | 'declined'
  dateOfCreation: number
}
