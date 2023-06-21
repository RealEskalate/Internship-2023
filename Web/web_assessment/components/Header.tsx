import React from 'react'
import Image from 'next/image'

function Header() {
  return (
    <div className=' px-20 pt-8 flex justify-between'>
        <h1 className='font-bold text-2xl'>Hakim<span className = "text-secondary">Hub</span></h1>
        <p>Jonathan Alemayew</p>
    </div>
  )
}

export default Header