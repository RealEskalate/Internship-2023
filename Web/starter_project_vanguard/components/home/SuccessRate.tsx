import React from 'react'
import { useGetAllActivitiesQuery } from '@/store/features/home/home-api'

import Activities from './Activities'
import SuccessCard from './SuccessCard'

const SuccessRate: React.FC = () => {
  const {data = [], isLoading, error} = useGetAllActivitiesQuery();

  return (
    <div>
      <div className="flex flex-col items-center justify-center mb-20 mt-30">
        <h1 className="text-3xl font-semibold text-center mx-7">
          Google SWE Interviews Acceptance
          <span className="sm:block ml-15"> Rate Comparison </span>
        </h1>
      </div>

      <div className="flex flex-col items-center mb-20 py-7 sm:justify-center bg-zinc-200 mx-7 rounded-xl">
        <div className="self-center w-2/4 py-3 mx-4 text-center aspect-auto">
          <p className="text-lg text-primary-text">
            A2SV students are <span className="font-semibold">35</span> times
            more likely to pass
            <span className="font-semibold"> Google SWE interviews </span>
            than average candiadates.
          </p>
        </div>

        <SuccessCard />
      </div>

      {data.map((activity) => (
        <Activities activity={activity} key={activity.url} />
      ))}
    </div>
  )
}

export default SuccessRate
