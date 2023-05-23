import React from 'react'
import Image from 'next/image'
import { DoctorDetail } from '@/types/doctors/doctor'
import { Router, useRouter } from 'next/router'

const DoctorCard: React.FC<DoctorDetail> = ({id, name, specialty, photo, institution}) => {
  const router = useRouter();
  const handleClick = (id : number) => {
    router.push(`/doctors/${id}`)
  }
  return (
    <div key={id} onClick={() => handleClick(id)} className='flex flex-col bg-white gap-1 items-center text-center drop-shadow-xl rounded-xl mx-4 w-2/12 h-44 py-2'>
      
      <div className='rounded-full'>
      <Image
          src={photo}
          alt="a2sv-logo"
          className='rounded-full border-2'
          width={50}
          height={50}
          unoptimized
        />
      </div>
        <h3 className="text-lg font-semibold text-black">
          {name}
        </h3>
        <div className='bg-blue-800 rounded-full px-2 text-white'>{specialty}</div>
        <p className='text-navbar-text text-sm'>{institution}</p>
    </div>
  )
}

export default DoctorCard