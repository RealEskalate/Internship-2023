import React from 'react'
import Image from 'next/image'

 interface GlassImageProps  {
  image: string,
  name: string,
  job: string,
  location: string
}

const GlassImage: React.FC<GlassImageProps> = ({ image, name, job, location }) => {
  return (
    <div className="relative inline-block sm:max-w-md md:max-w-md lg:w-auto">
      <Image  width={442} height={662}  src={`/img/success-stories-images/people/${image}`} alt="image"/>
      <div className="font-poppins text-gray-50 absolute bottom-0 left-0 right-0 backdrop-filter backdrop-blur-md rounded-xl w-full z-10">
        <div className="lg:m-4 lg:py-2">
          <p className="lg:pt-4 px-4  text-2xl font-bold">{name}</p>
          <p className="px-4 py-2  text-xl font-semibold">{job}</p>
          <p className="px-4 pb-4  text-xl">{location}</p>
        </div>
      </div>
    </div>
  )
}

export default GlassImage


