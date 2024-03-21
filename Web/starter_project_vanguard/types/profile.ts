import { StaticImageData } from 'next/image'
export interface User {
  id?: string
  username?: string
  firstName: string
  lastName: string
  email: string
  img?: StaticImageData|string
}