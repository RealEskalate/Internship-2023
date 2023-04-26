import React from 'react'
import a2svlogo from './../../public/img/successStory/a2svlogo.png'
import { FaFacebook } from 'react-icons/fa';
import { FaLinkedinIn } from 'react-icons/fa';
import { FaTelegramPlane } from 'react-icons/fa';
import { FaTwitter } from 'react-icons/fa';
import Image from 'next/image'
const Footer = () => {
  return (
    <div className='flex flex-row gap-70 justify-between mx-20'>
        <div className='top-20'>
            <Image src = {a2svlogo} alt = 'a2sv'/>
            <div className='my-20'>
                <p>© Copyright 2023 A2SV Foundation.</p>
                    <span>Terms of service</span>
                    <span className = "border-l-2 border-black m-0.5 h-2"></span>
                    <span>Privacy Policy</span>
             
            </div>
        </div>
        <div className='flex flex-col gap-3'>
            <h4>Out Teams</h4>
            <p>Advisors</p>
            <p>Board members</p>
            <p>Executives</p>
            <p>Groups</p>
        </div>
        <div className='flex flex-col gap-3'>
            <h4>Out Teams</h4>
            <p>Donate</p>
            <p>Get involved</p>
            <p>About us</p>
            <p>Groups</p>
        </div>
        <div className='flex flex-col gap-3'>
            <h4>Get in Touch</h4>
            <div className=''>
                <p>Questions or feedback?</p>
                <p>we would like to hear from you</p>
            </div>
             <div className='flex flex-row justify-around my-20'>
               <FaFacebook />
               <FaLinkedinIn />
               <FaTelegramPlane />
               <FaTwitter />
            </div>
        </div>
      
    </div>
  )
}

export default Footer
