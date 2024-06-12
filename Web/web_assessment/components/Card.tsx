import Image from 'next/image'
import React from 'react'
interface CardProps {
    photo: string,
    fullName: string,
    speciality: string,
    address: string
}
const Card:React.FC<CardProps> = (
  {photo, fullName, speciality, address}) => {
  return (
    <div className='w-[300px] h-[300px] ' >
        <div className='flex flex-col gap-1 p-3 shadow-md rounded-md'>
        <Image src={photo} alt={fullName} width={100} height={100} className='rounded-full border border-4 border-[#6C63FF] mx-auto'/>
        <h1 className='mx-auto'> {fullName}</h1>
        <p className='mx-auto bg-[#6C63FF] text-white font-bold p-2 rounded-md mb-5'>{speciality}</p>
        <address className='mx-auto'>{address}</address>
        </div>
    </div>
  )
}

export default Card