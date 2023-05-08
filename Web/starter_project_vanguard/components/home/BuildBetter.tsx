import React from 'react'
import Link from 'next/link'
import Image from 'next/image'
import buildBetterImage from '../../public/img/home/bulid-better-image.jpg'
import { AiOutlineMessage } from 'react-icons/ai'
const BuildBetter: React.FC  = () => {
  return (
    <div className="p-5">
      <div className="flex flex-col items-center justify-center">
        <div className="flex flex-col items-center justify-center">
          <h1 className="mx-4 text-4xl font-bold text-center sm:mx-11">
            Let&apos;s Build A Better <span className="block">Tomorrow</span>
          </h1>
        </div>

        <div className="pl-10 pr-10 mt-9">
          <p className="text-center text-gray-700 md:text-lg">
            A2SV up-skills high-potential university students, connects them
            with opportunities at top tech companies around the world, and
            creates digital solutions to urgent problems in their home
            countries. The program is free for students, making the opportunity
            available for youth who have the talentbut lack the mans to use it.
          </p>
        </div>

        <div className="p-3 mt-10 ml-4 font-semibold text-white bg-primary rounded">
          <Link href="/">
            <AiOutlineMessage className="inline-block w-6 h-6 mr-2" />
            Connect to our team
          </Link>
        </div>

        <div className="w-10/12 mt-14 aspect-video">
          <Image
            src={buildBetterImage}
            alt="Picture of the author"
            className=""
            width={1000}
            height={1000}
          />
        </div>
      </div>
    </div>
  )
}
export default BuildBetter
