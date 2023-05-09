import clsx from 'clsx'
import Image from 'next/image'
import React from 'react'

const HeroSection: React.FC = () => {
  const heroImages = [
    {
      className: 'left-[500px] -top-6',
      name: 'hero-image-1.png',
    },
    {
      className: '-top-8 left-14',
      name: 'hero-image-2.png',
    },
    {
      className: 'left-24 top-[340px] ',
      name: 'hero-image-3.png',
    },
  ]
  return (
    <div className="my-2 pt-8 2lg:my-8 flex">
      <div className="2lg:basis-2/5 ">
        <h1 className="uppercase font-bold text-3xl md:text-5xl 2lg:text-4xl xl:text-5xl  text-primary-text flex flex-col gap-4">
          <span>The team we&apos;re</span> <span>currently</span>{' '}
          <span>working with</span>{' '}
        </h1>
        <p className="text-secondary-text mt-8 text-xl">
          Meet our development team is a small but highly skilled and
          experienced group of professionals. We have a talented mix of web
          developers, software engineers, project managers and quality assurance
          specialists who are passionate about developing exceptional products
          and services.
        </p>
      </div>
      <div className="relative hidden 2lg:flex basis-3/5 p-40 flex-col gap-4 text-primary-text">
        <div className="absolute top-4 -z-10">
          <Image
            className=' w-[490px] xl:w-[530px]'
            src="/img/teams/hero-section/hero-background.png"
            width={550}
            height={500}
            alt={'background image'}/>
        </div>
        {heroImages.map((img, idx: number) => {
          return (
            <Image
              key={idx}
              className={clsx('absolute', img.className)}
              width={230}
              height={250}
              src={`/img/teams/hero-section/${img.name}`}
              alt={img.name}
            />
          )
        })}
          <h1 className="uppercase font-bold text-3xl md:text-5xl 2lg:text-4xl xl:text-5xl ml-24">
            <span className=" text-primary">Team</span> work
          </h1>
          <h1 className="uppercase font-bold text-3xl md:text-5xl 2lg:text-4xl xl:text-5xl ml-24">collaboration</h1>
          <h1 className="uppercase font-bold text-3xl md:text-5xl 2lg:text-4xl xl:text-5xl ml-24">
            <span className=" text-primary">Hard</span> work
          </h1>
        
      </div>
    </div>
  )
}

export default HeroSection
