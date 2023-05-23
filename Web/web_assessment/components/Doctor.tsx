import React from 'react'
import Image from 'next/image'
type DoctorProps = {
    doctor: any
}

const Doctor = ({doctor}: DoctorProps) => {
  return (
    <div className='flex flex-col items-center'>
        <div className="relative w-48 h-48">
          <Image className="rounded-full border-2 border-blue-500" src={doctor.photo} fill={true} alt="profile picture"/>
        </div>
    </div>
  )
}

export default Doctor