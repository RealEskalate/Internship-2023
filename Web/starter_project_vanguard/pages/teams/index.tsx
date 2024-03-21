import React from 'react'
import HeroSection from '@/components/teams/HeroSection'
import Members from '@/components/teams/Members'
const index = () => {
  return (
    <div className="lg:mx-10 mx-8">
      <HeroSection />
      <hr className="border mt-32 mb-16" />
      <Members />      
    </div>
  )
}

export default index
