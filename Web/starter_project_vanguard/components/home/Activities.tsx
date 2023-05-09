import React from 'react'
import Image from 'next/image'
import { Activity } from '@/types/home/Activity'
interface ActivityProp {
  activity: Activity
}

const Activities:React.FC<ActivityProp> = ({ activity }) => {
  return (
    <div className="flex flex-row justify-center mt-36">
      <div className="grid grid-flow-row gap-10 mx-8 auto-rows-max sm:grid-flow-col sm:auto-cols-fr sm:mx-11">
        <div
          className={` ${
            activity.left ? 'order-first' : 'sm:order-last place-self-end'
          }`}
        >
          <Image
            src={activity.url}
            alt={activity.altText}
            className="border-8 border-primary-text border-opacity-25 rounded-full aspect-square"
            width={320}
            height={320}
          />
        </div>
        <div
          className={`sm:col-span-2 self-end mb-14 ${
            activity.left ? 'text-end' : 'text-start'
          }`}
        >
          <h3 className="mb-6 text-3xl font-semibold">{activity.title}</h3>
          <p className="text-lg sm:text-xl text-primary-text">{activity.description}</p>
        </div>
      </div>
    </div>
  )
}

export default Activities