import React from 'react'
import HeroSection from '@/components/teams/HeroSection'
import Members from '@/components/teams/Members'
const index = () => {
  return (
    <div className="mx-10">
      <HeroSection />
      <hr className="border mt-32 mb-16" />
      <Members />
    </div>
  )
}

export default index
