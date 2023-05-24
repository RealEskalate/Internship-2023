import React from 'react'
import Image from 'next/image'
import Link from 'next/link'

interface Props {
    id:string;
    photoUrl: string;
    name: string;
    specialty: string;
    address: string;
  }
const DoctorCard: React.FC<Props> = ({ id, photoUrl, name, specialty, address }) => {

  return (
    <Link href={`/doctors/${id}`}>
    <div className="bg-white rounded-lg shadow-md overflow-hidden">
      <div className="flex justify-center items-center h-32 bg-gray-200">
        <div className="h-24 w-24 rounded-full overflow-hidden">
          <img src={photoUrl} alt={name} className="h-full w-full object-cover" />
        </div>
      </div>
      <div className="p-4 flex flex-col justify-center items-center">
        <h2 className="text-xl font-bold">{name}</h2>
        <div className='bg-blue-500 rounded max-width'>
        <p className="text-gray-600">{specialty}</p>
        </div>
        
        <p className="text-gray-600">{address}</p>
      </div>
    </div>
    </Link>
  )
}
export default DoctorCard
