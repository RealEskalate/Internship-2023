import React from 'react'
import Link from 'next/link'
import Image from 'next/image'

const HeroSection: React.FC = () => {
  return (
    <div className="mb-10 mt-11">
      <div className="grid w-full grid-flow-row gap-16 p-10 pl-4 mx-4 mt-8 sm:gap-10 auto-rows-max sm:grid-flow-col sm:auto-cols-fr">
        <div className="w-full ml-4 mt:11">
          <div>
            <h1 className="font-extrabold text-7xl sm:mb-7">
              Africa To
              <span className="text-primary"> Silicon Valley</span>
            </h1>

            <p className="mt-5 whitespace-normal text-primary-text sm:text-lg">
              A2SV up-skills high-potential university students, connects them
              with opportunities at top tech companies.
            </p>

            <div className="w-full mt-7">
              <div className="flex justify-start">
                <div className="px-3 py-2 mt-4 text-sm font-bold border-2 rounded-md text-primary border-primary whitespace-nowrap w-max">
                  <Link href="/">Get Started</Link>
                </div>

                <div className="px-3 py-2 mt-4 ml-3 text-sm font-semibold text-white uppercase rounded-md whitespace-nowrap bg-primary w-max">
                  <Link href="/">
                    Support Us
                    <svg
                      xmlns="http://www.w3.org/2000/svg"
                      fill="none"
                      viewBox="0 0 24 24"
                      stroke-width="1.5"
                      stroke="currentColor"
                      className="inline-block w-5 h-6 ml-1 font-bold"
                    >
                      <path
                        stroke-linecap="round"
                        stroke-linejoin="round"
                        d="M4.5 12h15m0 0l-6.75-6.75M19.5 12l-6.75 6.75"
                      />
                    </svg>
                  </Link>
                </div>
              </div>
            </div>
          </div>
        </div>

        <div className="w-full aspect-square place-self-start">
          <Image
            src="/images/landing-image.png"
            alt="Picture of A2SV students"
            className="overflow-visible"
            width={600}
            height={600}
          />
        </div>
      </div>
    </div>
  )
}

export default HeroSection
