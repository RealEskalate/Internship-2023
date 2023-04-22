import React from 'react'
import { Buttons } from './Buttons'
import Image from 'next/image'

const Landing = () => {
  return (
    <div className="mt-20 mb-10">
      <div className="grid w-full grid-cols-2 gap-10 p-10 pl-4 mt-8 place-content-center place-items-center">
        {/* left part goes here */}
        <div className="w-full ml-4">
          <div>
            {/* heading goes here */}
            <h1 className="text-4xl font-extrabold sm:mb-7">
              Africa To
              <span className="text-blue-600"> Silicon Valley</span>
            </h1>

            {/* text goes here */}
            <p className="mt-3 text-gray-700 whitespace-normal font-body md:text-lg md:font-semibold">
              A2SV up-skills high-potential university students, connects them
              with opportunities at top tech companies.
            </p>

            {/* buttons go here */}
            <div className="w-full sm:mt-7">
              <Buttons />
            </div>
          </div>
        </div>

        {/* right part goes here */}
        <div className="relative w-full mt-20 aspect-square place-self-start">
          {/* image element goes here */}
          <Image
            src="/images/landing_image.png"
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
