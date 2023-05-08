import Image from 'next/image'
import React from 'react'

interface ServiceProps {
  title: String
  image: string
  subtitle: String
  flexDirection: String
  textAlignment: String
}

const IndividualService: React.FC<ServiceProps> = ({
  title,
  image,
  subtitle,
  flexDirection,
  textAlignment,
}) => {
  return (
    <div className={`flex ${flexDirection} items-center justify-between`}>
      <div className="relative basis-3/12">
        <Image
          src={image}
          alt="landing page image"
          className="rounded-full"
          width={1000}
          height={1000}
        />
      </div>
      <div className={`flex flex-col ${textAlignment} basis-6/12 gap-6`}>
        <h3 className="text-primary-text font-semibold text-4xl Capitalize">
          {title}
        </h3>
        <p className="text-secondary-text text-2xl">{subtitle}</p>
      </div>
    </div>
  )
}

export default IndividualService
