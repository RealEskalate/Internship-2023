import Image from 'next/image'
import React from 'react'

const Navbar:React.FC = () => {
  return (
    <div className='flex flex-row pl-10 pr-10 pt-10 justify-between'>
      <div className='logo bg-white'>
        <Image className = "inline" src = "/img/cross.jpg" alt = "cross image" width = {50} height = {50}/>
        <Image className = "inline" src = "/img/hakimhub.jpg" alt = "hakim hub" width = {200} height={200}/>

      </div>
      <div>
        <Image className = "inline" src = "/img/man.jpg" alt = "man" width = {50} height={50}/>
        <span className = "text-xl">Jonathan Alemayehu</span>
      </div>
    </div>
  )
}

export default Navbar