import Image from 'next/image'
import React from 'react'
import {MdExpandMore} from 'react-icons/md'

const Header: React.FC = () => {
  return (
    <div className='flex gap-2 flex-wrap py-6 px-10 justify-between'>
        <div className='flex gap-2'>
        <Image src='/hakimhub.png' alt='hakim hub logo' width={39} height={39}></Image>
        <h1 className='text-textdark font-bold text-3xl'>Hakim<span className='text-secondary'>Hub</span></h1>
        </div>

        <div className='flex gap-1 items-center'>
        <Image src='/profile/user.png' alt='user profile' width={39} height={39}></Image>
        <h1 className='text-dimtext text-lg'>Jonathan Alemayehu</h1>
        <MdExpandMore className='w-6 h-6'></MdExpandMore>
        </div>

       
    </div>
  )
}

export default Header