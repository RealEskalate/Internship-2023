import React from "react"
import Image from "next/image"
import Link from 'next/link'
import impactStoriesImage from '../../public/img/home/impact-story-image.png'

const ImpactStroies: React.FC = () => {

  return (

    <div className="mb-40 mt-11 sm:mt-32">
      <h1 className="text-5xl font-bold text-center mb:10 sm:mb-20">
        Impact strories
      </h1>
      <div className="grid grid-flow-row gap-10 mx-4 auto-rows-max sm:grid-cols-2 sm:mx-18">
        <div className="mt-20">
          <h1 className="mb-2 text-2xl font-semibold">Abel Tesfaye</h1>
          <p className="text-lg mb-7">Software Engineer at Google</p>
          <p className="w-full text-base text-primary-text">
            &quot;When I joined A2SV in 2019, I found the concept of data structures
            and algorithms quite challenging. A2SV&apos;s smooth learning process and
            dedicated team molded me to see the peak of my abilities. Through
            A2SV&apos;s effective education and continual support, I passed Google&lsquo;s
            internship interviews and attended a summer internship at Google in
            Amsterdam. However, the A2SV program and training is beyond
            technical education and interview preparation. As an A2SVian, I also
            learned the values of putting humanity first, giving back to our
            community, and utilizing teamwork with my colleagues, which I can
            now consider my big family. After completing three remarkable months
            at Google, I was offered a full-time position at Google&lsquo;s London
            office for 2022.&quot;
          </p>
          <div>
            <div className="px-5 py-3 mt-4 text-base text-center text-white bg-primary rounded w-max whitespace-nowrap">
              <Link href="/">See More</Link>
            </div>
          </div>
        </div>
        <div className="w-full mt-11 aspect-square">
          <Image
            src={impactStoriesImage}
            alt="Picture of A2SV students"
            className="overflow-visible"
            width={1000}
            height={1000}
          />
        </div>
      </div>
    </div>
  )
}

export default ImpactStroies
