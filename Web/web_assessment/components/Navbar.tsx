import Image from 'next/image'
import React from 'react'
import {AiOutlineDown} from "react-icons/ai"
import logo from "@/public/img/logo.png"
import profile from "@/public/img/user.png"

const Navbar:React.FC = () => {
  return (
    <nav className='p-5'>
        <div className='flex justify-between'>
            <div>
                <Image src={logo} alt='Hakim Logo'/>
            </div>
            <div className='flex gap-2'>
                <Image src={profile} alt='Hakim Logo'/>
                <span className='my-auto'>Yonathan Alemayehu</span>
                <AiOutlineDown className='my-auto'/>
            </div>
        </div>
    </nav>
  )
}

export default Navbar