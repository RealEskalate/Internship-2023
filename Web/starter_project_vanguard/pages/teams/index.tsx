import React from 'react'
import HeroSection from '@/components/teams/HeroSection'
import Members from '@/components/teams/Members'
import Pagination from '@/components/common/Pagination'
const index = () => {
  return (
    <div className="lg:mx-10 mx-8">
      <HeroSection />
      <hr className="border mt-32 mb-16" />
      <Members />
      <div className="my-14">
        <Pagination/>
      </div>
      
    </div>
  )
}

export default index
