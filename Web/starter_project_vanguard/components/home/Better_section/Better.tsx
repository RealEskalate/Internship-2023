import React from 'react'
import Link from 'next/link'
import Image from 'next/image'
const Better = () => {
  return (
    <div className="p-5 bg-white">
      <div className="flex flex-col items-center justify-center">
        {/* heading goes here */}

        <div className="flex flex-col items-center justify-center">
          <h1 className="text-4xl font-bold">Let's Build A Better</h1>

          <h1 className="text-4xl font-bold">Tomorrow</h1>
        </div>

        {/* content goes here */}
        <div className="pl-10 pr-10 mt-9">
          <p className="text-center text-gray-700 md:text-lg md:font-semibold">
            A2SV up-skills high-potential university students, connects them
            with opportunities at top tech companies around the world, and
            creates digital solutions to urgent problems in their home
            countries. The program is free for students, making the opportunity
            available for youth who have the talentbut lack the mans to use it.
          </p>
        </div>
        {/* button goes here */}
        <div className="px-6 py-4 mt-10 ml-4 font-semibold text-white bg-blue-600 border-2 border-blue-500 rounded">
          <Link href="/">
            <svg
              xmlns="http://www.w3.org/2000/svg"
              fill="none"
              viewBox="0 0 24 24"
              stroke-width="1.5"
              stroke="currentColor"
              className="w-6 h-6 inline-block mr-2"
            >
              <path
                stroke-linecap="round"
                stroke-linejoin="round"
                d="M8.625 12a.375.375 0 11-.75 0 .375.375 0 01.75 0zm0 0H8.25m4.125 0a.375.375 0 11-.75 0 .375.375 0 01.75 0zm0 0H12m4.125 0a.375.375 0 11-.75 0 .375.375 0 01.75 0zm0 0h-.375M21 12c0 4.556-4.03 8.25-9 8.25a9.764 9.764 0 01-2.555-.337A5.972 5.972 0 015.41 20.97a5.969 5.969 0 01-.474-.065 4.48 4.48 0 00.978-2.025c.09-.457-.133-.901-.467-1.226C3.93 16.178 3 14.189 3 12c0-4.556 4.03-8.25 9-8.25s9 3.694 9 8.25z"
              />
            </svg>
            Connect to our team
          </Link>
        </div>
        {/* image goes here */}

        <div className="relative w-10/12 mt-10 aspect-video">
          <Image
            src="/images/group.jpg"
            alt="Picture of the author"
            className="object-contain rounded-3xl"
            fill
          />
        </div>
      </div>
    </div>
  )
}
export default Better
