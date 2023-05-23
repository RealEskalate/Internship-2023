import React from 'react';
import { DoctorData } from '../../types/doctor';
import Image from 'next/image'
import Link from 'next/link';

interface DoctorCardProps {
  doctor: DoctorData;
}




const DoctorCard: React.FC<DoctorCardProps> = ({ doctor }) => {

  return (
  <Link href={`./doctor-detail/`} passHref>
    <div className="rounded-lg shadow-md bg-white p-4 mt-9 mb-9">
      <h3 className="text-xl font-semibold">{doctor._id}</h3>
      <p className="text-gray-500"> special </p>
      {/* <Image
                  src={doctor.photo}
                  alt={''}
                  width={50}
                  height={50}
                  className={`rounded-full object-cover`}
                /> */}

        
                
            
    </div>
  </Link>
  );
};

export default DoctorCard;
