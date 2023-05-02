import Image from 'next/image'

import HeroSection from '@/components/home/HeroSection'

export default function Home() {
  return (
    <div className="min-h-screen bg-white font-{poppins} scroll-smooth">
      <HeroSection />
    </div>
  )
}
