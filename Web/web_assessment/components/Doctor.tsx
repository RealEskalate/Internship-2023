import React from 'react'
import Image from 'next/image'
type DoctorProps = {
    doctor: any
}

const Doctor = ({doctor}: DoctorProps) => {
  return (
    <div className='flex flex-col items-center rounded-lg shadow-lg p-3 gap-2'>
        <div className="relative w-48 h-48">
          <Image className="rounded-full border-4 border-blue-500" src={doctor.photo} fill={true} alt="profile picture"/>
        </div>
        <div>{doctor.fullName}</div>
        <div className='rounded-full bg-blue-500 p-2 text-white'>proffession</div>
        <div className='text-center w-52'>Washington Medical Center | MCM korean Hospital</div>
    </div>
  )
}

export default Doctor