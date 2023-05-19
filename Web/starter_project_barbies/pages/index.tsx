import { Inter } from 'next/font/google'
import {BsArrowRight} from 'react-icons/bs'
const inter = Inter({ subsets: ['latin'] })
import Hero from '@/components/home/Hero'
import BuildBetter from '@/components/home/BuildBetter'
import SuccessRate from '@/components/home/SuccessRate'
import ImpactStories from '@/components/home/ImpactStories'
import SupportUs from '@/components/home/SupportUs'

export default function Home() {
  return (
    <main className='p-8' >
      <div>
        <Hero/>
        <BuildBetter/>
       <SuccessRate/>
      <SupportUs/>
      <ImpactStories/>
    </div>
    </main>
  )
}