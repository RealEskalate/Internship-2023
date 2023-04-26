import React from 'react'
import { FaFacebook } from 'react-icons/fa';
import { FaLinkedinIn } from 'react-icons/fa';
import { FaTelegramPlane } from 'react-icons/fa';
import { FaTwitter } from 'react-icons/fa';
import Image from 'next/image'
import a2svlogo from './../../public/img/successStory/a2sv-logo.png'
const icons = [<FaFacebook/>,<FaLinkedinIn/>,<FaTelegramPlane/>,<FaTwitter/> ]
const Footer = () => {
  return (
    <div className='flex flex-row gap-70 justify-between mx-20'>
        <div className='top-20'>
            <Image src = {a2svlogo} alt = 'a2sv'/>
            <div className='my-20'>
                <p className='font-light text-xs'>© Copyright 2023 A2SV Foundation.</p>
                    <span className='font-light text-xs'>Terms of service</span>
                    <span className = "border-l-2 border-black-600 m-1.5 h-2"></span>
                    <span className='font-light text-xs'>Privacy Policy</span>
             
            </div>
        </div>
        <div className='flex flex-col gap-3'>
            <h4 className='font-semibold'>Our Teams</h4>
            <p className='font-light'>Advisors</p>
            <p className='font-light'>Board members</p>
            <p className='font-light'>Executives</p>
            <p className='font-light'>Groups</p>
        </div>
        <div className='flex flex-col gap-3'>
            <h4 className='font-semibold'>Our Teams</h4>
            <p className='font-light'>Donate</p>
            <p className='font-light'>Get involved</p>
            <p className='font-light'>About us</p>
            <p className='font-light'>Groups</p>
        </div>
        <div className='flex flex-col gap-3'>
            <h4 className='font-semibold'>Get in Touch</h4>
            <div className=''>
                <p className='font-light'>Questions or feedback?</p>
                <p className='font-light'>we would like to hear from you</p>
            </div>
             <div className='flex flex-row justify-around my-20'>
                {icons.map((item, index) => (
                <div key={index}> {item} </div>
                 ))}    
            </div>
        </div>
      
    </div>
  )
}

export default Footer
