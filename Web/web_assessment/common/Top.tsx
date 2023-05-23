import React from 'react'
import Image from 'next/image'
import comp from './../public/image/Component 35.jpg'
const Top = () => {
  return (
    <div className='mx-20'>
      <Image width={150} height={150} src = {comp} alt = "logo" priority/>
      <div className="box-border absolute w-1006 h-50 left-170 top-151 border border-gray-300 rounded-full">
      
        </div>
    </div>
    

  )
}

export default Top
