import React from 'react'
import {MdOutlineKeyboardArrowRight} from 'react-icons/md'
const Footer: React.FC= () => {
  return (

    <div className='p-8  bg-primary text-bgsecondary '>
 <div className='flex flex-wrap justify-between'>

      <div>
        <p className='font-bold text-3xl'>HakimHub</p>
      </div>

      <div className='flex flex-wrap gap-6 justify-between'>
        <div className='flex flex-col gap-4'>
          <p className='text-lg'>Get Connected</p>
          <div className='flex gap-1 items-center'> <MdOutlineKeyboardArrowRight className='w-4 h-4'></MdOutlineKeyboardArrowRight> <p>For Physicians</p> </div>
          <div className='flex gap-1 items-center'> <MdOutlineKeyboardArrowRight className='w-4 h-4'></MdOutlineKeyboardArrowRight> <p>For Physicians</p> </div>
        </div>
        <div className='flex flex-col gap-4'>
          <p className='text-lg'>Actions</p>
          <div className='flex gap-1 items-center'> <MdOutlineKeyboardArrowRight className='w-4 h-4'></MdOutlineKeyboardArrowRight> <p>For Doctors</p> </div>
          <div className='flex gap-1 items-center'> <MdOutlineKeyboardArrowRight className='w-4 h-4'></MdOutlineKeyboardArrowRight> <p>For Physicians</p> </div>
        </div>
        <div className='flex flex-col gap-4'>
          <p className=' text-lg'>Company</p>
          <div className='flex gap-1 items-center'> <MdOutlineKeyboardArrowRight className='w-4 h-4'></MdOutlineKeyboardArrowRight> <p>About Us</p> </div>
          <div className='flex gap-1 items-center'> <MdOutlineKeyboardArrowRight className='w-4 h-4'></MdOutlineKeyboardArrowRight> <p>Career</p> </div>
          <div className='flex gap-1 items-center'> <MdOutlineKeyboardArrowRight className='w-4 h-4'></MdOutlineKeyboardArrowRight> <p>Join Our Teem</p> </div>
        </div>
      </div>
      

      
    </div>
    <hr className='my-3' />
    <div className='justify-between'>
        <div className='flex gap-3'>
          <p>Privacy</p>
          <p>Terms of Use</p>
        </div>

      </div>
    </div>
   
  )
}

export default Footer