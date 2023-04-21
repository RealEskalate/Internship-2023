import { Blog, User } from '@/types/models'
import user1Photo from '../../public/blogImages/user1Photo.png'
import card1Photo from '../../public/blogImages/card1Photo.png'
export const user1: User = {
  id: 1,
  firstName: 'Fred',
  lastName: 'Boone',
  email: 'Fred.Boone@gmail.com',
  photoUrl: user1Photo.src,
}
export const card1: Blog = {
  id: 1,
  title: 'Design Liberalized Exchange Rate Management',
  tags: ['UI/UX', 'Development'],
  status: 'approved',
  likes: 2300,
  description:
    'A little personality goes a long way, especially on a business blog.\
       So don’t be afraid to let loose.\
       A little personality goes a long way, especially on a business blog.\
       So don’t be afraid to let loose.A little personality goes a long way, especially on a business blog.\
       So don’t be afraid to let loose.',
  writter: user1,
  dateOfCreation: Date.now(),
  photoUrl: card1Photo.src,
}
