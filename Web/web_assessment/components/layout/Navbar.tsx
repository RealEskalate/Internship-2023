import Image from 'next/image'
import React from 'react'
import {AiOutlineDown} from "react-icons/ai"


const Navbar:React.FC = () => {
  return (
    <nav className='p-5'>
        <div className='flex justify-between'>
            <div>
                <Image src="/logo.png" width={175} height={175} alt='Hakim Logo'/>
            </div>
            {/*  Add the k and the logut button below */}
            <div className='flex gap-2'>
                <Image src="/logo.png" width={25} height={25}  alt='Hakim Logo'/>
                
                <AiOutlineDown className='my-auto'/>
            </div>
        </div>
    </nav>
  )
}

export default Navbar