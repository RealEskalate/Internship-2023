import { StaticImageData } from 'next/image'
export interface User {
  firstName: string
  lastName: string
  email: string
  img: StaticImageData
}