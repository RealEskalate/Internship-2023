import React from 'react'
import { BsFacebook, BsInstagram, BsTwitter, BsLinkedin } from 'react-icons/bs'
import { IoIosArrowForward } from 'react-icons/io'

type Props = {}

const Footer = (props: Props) => {
  return (
    <div className='flex flex-col h-44 bg-blue-500 divide-y-2 divide-slate-50 w-full'>
      <div className='flex justify-between'>
        <div className='font-bold text-white text-4xl'>HakimHub</div>
        <div className='flex gap-5'>
          <div className='space-y-3'>
            <div className='text-white font-bold'>Get Connected</div>
            <div className='flex items-center text-white'>
              <IoIosArrowForward color='white' />
              <div className='text-white'>For physicians</div>
            </div>
            <div className='flex items-center text-white'>
              <IoIosArrowForward color='white' />
              <div className='text-white'>For Hospitals</div>
            </div>          
          </div>
          <div className='space-y-3'>
            <div className='text-white font-bold'>Actions</div>
            <div className='flex items-center text-white'>
              <IoIosArrowForward color='white' />
              <div className='text-white'>For a Doctor</div>
            </div>
            <div className='flex items-center text-white'>
              <IoIosArrowForward color='white' />
              <div className='text-white'>For a Hospital</div>
            </div>          
          </div>
          <div className='space-y-3'>
            <div className='text-white font-bold'>Company</div>
            <div className='flex items-center text-white'>
              <IoIosArrowForward color='white' />
              <div className='text-white'>About Us</div>
            </div>            
            <div className='flex items-center text-white'>
              <IoIosArrowForward color='white' />
              <div className='text-white'>Career</div>
            </div>   
            <div className='flex items-center text-white'>
              <IoIosArrowForward color='white' />
              <div className='text-white'>Join Our Team</div>
            </div>       
          </div>
        </div>
      </div>
      <div className='flex justify-between px-3'>
        <div className='flex gap-10'>
          <p className='text-white'>Privacy Policy</p>
          <p className='text-white'>Terms of Use</p>
        </div>
        <div className='flex gap-5'>
          <BsFacebook color='white' />
          <BsLinkedin color='white' />
          <BsInstagram color='white' />
          <BsTwitter color='white' />
        </div>
      </div>
    </div>
  )
}

export default Footer