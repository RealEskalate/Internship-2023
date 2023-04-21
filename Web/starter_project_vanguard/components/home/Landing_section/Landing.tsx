import React from 'react'
import { Buttons } from './Buttons'
import Image from 'next/image'

const Landing = () => {
  return (
    <div className="mt-20 mb-10">
      <div className="grid grid-cols-2 w-full gap-10 pl-4 p-10 mt-8 place-content-center place-items-center">
        {/* left part goes here */}
        <div className="w-full ml-4">
          <div>
            {/* heading goes here */}
            <h1 className="text-4xl font-extrabold">
              Africa To
              <span className="text-blue-600"> Silicon Valley</span>
            </h1>

            {/* text goes here */}
            <p className="font-body whitespace-normal mt-3 md:text-lg md:font-semibold text-gray-700">
              A2SV up-skills high-potential university students, connects them
              with opportunities at top tech companies.
            </p>

            {/* buttons go here */}
            <div className="w-full">
              <Buttons />
            </div>
          </div>
        </div>

        {/* right part goes here */}
        <div className="relative w-full aspect-square place-self-start mt-20">
          {/* image element goes here */}
          <Image
            src="/images/image_collection.png"
            alt="Picture of the author"
            className="object-cover overflow-visible"
            fill
          />
        </div>
      </div>
    </div>
  )
}

export default Landing
