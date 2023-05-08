import React from 'react'
import YearlySucess from './YearlySucess'
import successRates from '../../../data/home/success_rates.json'
import activities from '../../../data/home/activities.json'
import { Activities } from './Activities'


const SuccessRate = () => {
  return (
    <div className="mt-20">
      <div className="flex flex-col items-center justify-center mb-20 mt-30">
        <h1 className="text-3xl font-semibold text-center mx-7">
          Google SWE Interviews Acceptance
          <span className="sm:block ml-15"> Rate Comparison </span>
        </h1>
      </div>

      <div className="flex flex-col items-center mb-20 limit_size:flex-row sm:justify-center bg-bg_color mx-7 rounded-xl">
        <div className="self-center w-2/4 py-3 mx-4 text-center limit_size:w-1/5 limit_size:h-1/5 aspect-auto">
          <p className="text-sm text-gray-700">
            A2SV students are <span className="font-semibold">35</span> times
            more likely to pass{' '}
            <span className="font-semibold">Google SWE interviews </span>
            than average candiadates.
          </p>
        </div>

        <div className="flex flex-col items-center w-full grow sm:flex-row sm:justify-center">
          {successRates.map((info) => (
            <YearlySucess info={info} key={info.id} />
          ))}
        </div>
      </div>

      {activities.map((activity) => (
        <Activities activity={activity} key={activity.url} />
      ))}
    </div>
  )
}

export default SuccessRate
