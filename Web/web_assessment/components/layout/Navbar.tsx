import React from 'react'
import Image from 'next/image'
import { AiOutlineDown } from 'react-icons/ai'

const Navbar: React.FC = () => {
  return (
    <div className='flex flex-row items-start justify-between font-poppins px-4 py-2'>
      <div className='flex flex-row gap-1'>
      <Image
          src='/img/navigation/logo.png'
          alt="a2sv-logo"
          width={20}
          height={20}
        />
        <h1 className="text-xl font-bold text-center md:text-left text-primary">
          Hakim<span className="text-secondary">Hub</span>
        </h1>
        </div>
      <div className='flex flex-row gap-1'>
        <Image
          src='/img/navigation/user.png'
          alt="profile image"
          className="rounded-full"
          width={20}
          height={20}
        />
        <p className='text-navbar-text text-sm'>Jonathan Alemayehu</p>
        <AiOutlineDown className="hidden md:flex self-center" size={10} />
      </div>
    </div>
  )
}

export default Navbar