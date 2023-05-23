

import { useGetDoctorsQuery } from '@/store/features/doctors/doctor-api';
import { Doctor } from '@/types/doctor/doctor';
import Image from 'next/image';
import Link from 'next/link';
import React from 'react'
import DoctorDetail from './DoctorDetail';


const DoctorItem = ({ fullName, phoneNumbers, emails, photo, _id, institutionID_list, summary, speciality, education }: Doctor) => {
  const handleClick = () => {
    // I want to pass data to the DoctorDetail page
    // I want to use the Link component from nextjs
  };

  return (
    <Link href={`doctors/profile`} onClick={handleClick} className="flex flex-col items-center justify-center w-full h-full p-4 bg-white rounded-lg shadow-md">
      <div className="flex items-center justify-center w-16 h-16 mb-4 rounded-full border-2 border-primary bg-gradient-to-br from-blue-500 to-blue-600">
        <Image
          className="object-cover w-full h-full rounded-full"
          src={photo}
          alt={fullName}
          width={64}
          height={64}
        />
      </div>
      <h2 className="mb-2 text-xl font-semibold text-black">
        {fullName}
      </h2>
      <p className="text-sm text-gray-700">{summary}</p>
      <p className="text-sm text-gray-300 bg-primary rounded-full px-3 py-1">
        {speciality[0].name}
      </p>
      <p className="text-sm text-gray-700">
        {institutionID_list[0].institutionName}
      </p>
    </Link>
  );
};



export default DoctorItem