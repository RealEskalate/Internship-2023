import React from 'react'
import Image from 'next/image'
import { DoctorDetail } from '@/types/doctors/doctor'
const DoctorCard: React.FC<DoctorDetail> = ({id, name, specialty, photo, institution}) => {
  return (
    <div key={id} className='flex flex-col bg-white gap-1 items-center text-center drop-shadow-xl rounded-xl mx-4 w-2/12 py-2'>
      <div className='rounded-full'>
      <Image
          src={photo}
          alt="a2sv-logo"
          width={50}
          height={50}
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