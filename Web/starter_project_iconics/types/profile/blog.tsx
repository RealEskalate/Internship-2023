import { User } from './user'
export type Blog = {
  id: number
  title: string
  photoUrl: string
  description: string
  tags: string[]
  writter: User
  likes: number
  status: 'pending' | 'approved' | 'declined'
  datePosted: string
}
