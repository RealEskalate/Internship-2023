import React from 'react'
import { BsFacebook, BsInstagram, BsTwitter, BsLinkedin } from 'react-icons/bs'
import { IoIosArrowForward } from 'react-icons/io'

type Props = {}

const Footer = (props: Props) => {
  return (
    <div className='fixed flex flex-col bottom-0 h-44 bg-blue-500 divide-y-2 divide-slate-50 w-full'>
      <div>
        <div className='font-bold text-white text-4xl'>HakimHub</div>
        <div className='flex gap-5'>
          <div className='space-y-3'>
            <div className='text-white font-bold'>Get Connected</div>
            <div className='text-white'><IoIosArrowForward color='white' />{' '}For physicians</div>
            <div className='text-white'><IoIosArrowForward color='white' />{' '}For Hospitals</div>
          </div>
          <div className='space-y-3'>
            <div className='text-white font-bold'>Actions</div>
            <div className='text-white'><IoIosArrowForward color='white' />{' '}For a Doctor</div>
            <div className='text-white'><IoIosArrowForward color='white' />{' '}For a Hospital</div>
          </div>
          <div className='space-y-3'>
            <div className='text-white font-bold'>Company</div>
            <div className='text-white'><IoIosArrowForward color='white' />{' '}About Us</div>
            <div className='text-white'><IoIosArrowForward />{' '}Career</div>
            <div className='text-white'><IoIosArrowForward color='white' />{' '}Join Our Team</div>
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