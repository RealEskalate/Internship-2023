import React from 'react'
import Image from 'next/image'
import Link from 'next/link'
const HelpUs = () => {
  return (
    <div className="mb-20">
      <div className="relative mt-20 bg-fixed h-72 aspect-auto">
        <Image
          src="/img/home-page/africa.png"
          alt="African image for background"
          className="w-full bg-opacity-100 aspect-auto"
          fill
        />
        <div className="relative z-10 flex flex-col items-center justify-center h-full mt-28">
          <h1 className="text-2xl font-bold text-center text-gray-200">
            Help us sustain our mission!
          </h1>
          <div className="px-8 py-3 mt-6 ml-4 font-bold text-blue-700 bg-white rounded whitespace-nowrap">
            <Link href="/">Support Us</Link>
          </div>
        </div>
      </div>
    </div>
  )
}
export default HelpUs
