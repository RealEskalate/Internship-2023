import Image from 'next/image'
import { Inter } from 'next/font/google'
import DoctorListPage from './doctor'

const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  return (
    <DoctorListPage/>
  )
}
