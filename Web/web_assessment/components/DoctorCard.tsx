import React from 'react'
import { Doctor } from '@/type/hakim'
import Image from 'next/image'
function DoctorCard({singleDoctor}:{singleDoctor:Doctor})  {
  return (

    <div className = " flex flex-col items-center rounded-xl shadow-lg">
        <div className = " rounded-full relative">
            <Image className = "object-contain rounded-full border-4 border-primary" width={100} height = {100} src={singleDoctor.photo} alt='doctor'></Image>
            </div>
        <h1 className = "font-bold">{singleDoctor.fullName}</h1>
        <p className = "bg-primary text-white rounded-3xl p-1">{singleDoctor.speciality[0].name}</p>
        <p className = 'text-lighttext'>{singleDoctor.mainInstitution.institutionName}</p>
    
    </div>
  )
}

export default DoctorCard