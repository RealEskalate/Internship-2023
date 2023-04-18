import Image from 'next/image'
import { Inter } from 'next/font/google'
import Navbar from '@/components/common/Navbar'

const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  return (
    <main className="mx-10 my-5">
      <Navbar/>
      <div className="z-10 w-full max-w-5xl items-center justify-between font-mono text-sm lg:flex">
      </div>
    </main>
  )
}
