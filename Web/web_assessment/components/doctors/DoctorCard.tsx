import React from 'react'
import doctor from './doctor.json'
import SpecialityTag from './SpecialityTag'
import Image from 'next/image'
interface DoctorCardProps{
  _id: string
  fullname: string,
  photo: string,
  speciality: string,
  hospital: string
}

const DoctorCard: React.FC<DoctorCardProps> = ({_id, fullname, photo, speciality, hospital}) => {
    
  return (
    <div className='w-80 min-w-80 items-center p-2 pt-12'>

        <div className='bg-bgsecondary flex flex-col justify-center rounded-3xl items-center gap-1'>
            <Image unoptimized className='rounded-full border-2 border-primary -mt-[45px]' src={photo} alt={doctor.fullName} width={90} height={90}></Image>
            <p className='font-bold'> {fullname}</p>
        
            <SpecialityTag title={speciality}></SpecialityTag>
        
            
            <p className='text-dimtext p-2 text-center my-2'>
            {hospital}
            </p>
        </div>
        
    </div>
  )
}

export default DoctorCard