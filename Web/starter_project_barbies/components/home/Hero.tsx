import React from 'react'
import {BsArrowRight} from 'react-icons/bs'
import Image from 'next/image'
import landingImageOne from '../../public/img/home/landing-images/landing-image-1.png'
import landingImageTwo from '../../public/img/home/landing-images/landing-image-2.png'
import landingImageFive from '../../public/img/home/landing-images/landing-image-5.png'
import landingImageThree from '../../public/img/home/landing-images/landing-image-3.png'
import landingImageFour from '../../public/img/home/landing-images/landing-image-4.png'
function Hero() {
  return (
    <div>
          <div className='flex items-start py-32 pt-20  gap-20'>
          <div>
            <h1 className='capitalize font-bold text-5xl py-12 '>africa to <span className='text-primary'>silcon valley</span></h1>
            <p className=' pb-6 text-xl'>A2SV up-skills high-potential university students, connects them with opportunities at top tech companies</p>
            <button className='mr-4 border-primary border-2 py-2 px-6 capitalize font-semibold text-primary rounded-md'>get started</button>
            <button className=' bg-primary py-2 px-6 uppercase font-semibold text-white rounded-md'>support us <BsArrowRight className='inline'></BsArrowRight></button>
          </div>
          <div>
            <div className='hidden lg:grid  grid-cols-3'>
              
              <div className='relative'>
              <Image className=' w-52 h-52 object-contain bg-yellow-400 rounded-full' alt="picture of a student" src={landingImageFive} />
              <div className='w-5 h-5 rounded-full border-2 border-black  absolute right-0 top-0 -m-6'>

              </div>
              </div>
              <div className='relative bg-black text-white w-40 h-40 rounded-t-full rounded-l-full self-end'>
                <p className='w-fit m-auto p-5 capitalize'>active <br></br>members</p>
                <p className='absolute right-0 bottom-0 p-3 text-2xl font-bold'>1,200</p>
              </div>
              <Image className='bg-[#A35DE9] rounded-t-full rounded-b-full w-32 h-60 object-contain -ml-12 -mb-4 ' alt='women image' src={landingImageOne} />
              <Image alt='landing image' src={landingImageTwo} />
              
              <Image alt="picture of a student" className=' w-32 h-32 justify-self-center' src={landingImageFour } />
              <div className=' w-40 h-40 bg-yellow-400 rounded-3xl rounded-tr-[9rem] mt-12 -ml-8 justify-self-start'>
              </div>
              <div>
              </div>
              <Image className='-mt-24 w-48' alt='landing image' src={landingImageThree} />
              <div className='w-16 h-16 justify-self-center bg-[#F14A25] rounded-full mt-2 mr-36 '>
              </div>
            </div>
          </div>

        </div>
    </div>
  )
}

export default Hero