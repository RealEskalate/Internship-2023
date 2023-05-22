import React from 'react'
import Image from 'next/image'

interface ActivityProp {
  id: number,
  url: string
  title: string
  description: string
  altText: string
}

const Activities: React.FC<ActivityProp> = ({
  id,
  url,
  title,
  description,
  altText,
}) => {
  return (
    <div className="flex flex-row justify-center mt-36">
      <div className="grid grid-flow-row gap-10 mx-8 auto-rows-max sm:grid-flow-col sm:auto-cols-fr sm:mx-11">
        <div
          className={` ${
            (id % 2 != 0) ? 'order-first' : 'sm:order-last place-self-end'
          }`}
        >
          <Image
            src={url}
            alt={altText}
            className="border-8 border-opacity-25 rounded-full border-primary-text aspect-square"
            width={320}
            height={320}
          />
        </div>
        <div
          className={`sm:col-span-2 self-end mb-14 ${
            (id % 2 != 0) ? 'text-end' : 'text-start'
          }`}
        >
          <h3 className="mb-6 text-3xl font-semibold">{title}</h3>
          <p className="text-lg sm:text-xl text-primary-text">{description}</p>
        </div>
      </div>
    </div>
  )
}

export default Activities