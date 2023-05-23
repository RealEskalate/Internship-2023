import Image from 'next/image';
import { FC } from 'react';
import { Doctor } from '../types/doctor'


interface DoctorCardProps {
  doctor: Doctor;
}

const DoctorCard: FC<DoctorCardProps> = ({doctor}) => {
  
  return (
    <div className="display-flex flex-row bg-white rounded-lg shadow-md p-6 max-w-xs mx-auto">
      <div className="absolute w-90 h-89 left-185 top-927 bg-doctors6 border-4 border-indigo-600">
        <Image src={doctor?.image} alt="Doctor Image" width={90} height={80} />
      </div>
      <h2 className="absolute my-5 w-154 h-23 left-153 top-1026 font-poppins font-semibold text-18 leading-27 text-black">{doctor?.name}</h2>
      <p className="w-83 h-21 my-5 font-poppins font-normal text-14 leading-21 text-gray-400 flex-none order-0 flex-grow-0">{doctor?.career}</p>
      <p className="absolute my-5 w-284 h-42 left-89 top-1111 font-poppins font-normal text-14 leading-21 text-center text-gray-600">{doctor?.placeOfWork}</p>
    </div>
  );
};

export default DoctorCard;
