import { useGetServicesQuery } from '@/store/features/home/services/services-api'
import React from 'react'
import Error from '../common/Error'
import IndividualService from './IndividualService'

const Services: React.FC = () => {
  const {
    data: services,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetServicesQuery()
  if (isLoading) {
    return (
      <div className="flex flex-col items-center w-full p-28 gap-y-20">
        {Array.from({ length: 3 }).map((_, index) => (
          <div
            key={index}
            className={`flex ${
              index % 2 ? 'flex-row-reverse' : 'flex-row'
            } items-center justify-between w-full animate-pulse`}
          >
            <div className="relative w-3/12">
              <div className="bg-gray-300 h-[25vw] w-[25vw] xl:h-72 xl:w-72 rounded-full"></div>
            </div>
            <div className={`flex flex-col w-5/12 gap-6 `}>
              <div
                className={`bg-gray-200 h-6 rounded-full w-1/2 mb-2 ${
                  index % 2 ? 'self-start' : 'self-end'
                }`}
              ></div>
              {Array.from({ length: 3 }).map((_, idx) => (
                <div
                  key={idx}
                  className={`bg-gray-200 h-4 rounded-full w-11/12 ${
                    index % 2 ? 'self-start' : 'self-end'
                  }`}
                ></div>
              ))}
            </div>
          </div>
        ))}
      </div>
    )
  } else if (isError || !isSuccess || !services || error) {
    return <Error />
  }

  return (
    <div className="flex flex-col items-center p-28 gap-y-20">
      {services.map((service, index) => (
        <IndividualService
          key={service.id}
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
