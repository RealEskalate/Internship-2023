import services from '@/data/home/service'
import React from 'react'
import IndividualService from './IndividualService'

const Services: React.FC = () => {
  return (
    <div className="flex flex-col items-center p-28 gap-y-20">
      {services.map((service, index) => (
        <IndividualService
          key={service.title}
          title={service.title}
          image={service.image}
          subtitle={service.subtitle}
          flexDirection={index % 2 ? 'flex-row-reverse' : 'flex-row'}
          textAlignment={index % 2 ? 'text-left' : 'text-right'}
        />
      ))}
    </div>
  )
}

export default Services
