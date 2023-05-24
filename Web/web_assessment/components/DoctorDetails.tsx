import React from 'react';
import { DoctorDetails } from '@/types';

interface DoctorDetailsProps {
  details: DoctorDetails;
}

const DoctorDetails: React.FC<DoctorDetailsProps> = ({ details }) => {
  return (
    <div className="bg-white shadow-md rounded-lg p-4">
      <img src={details.picture} alt={details.name} className="w-full h-32 object-cover mb-4" />
      <h2 className="text-xl font-bold">{details.name}</h2>
      <p>{details.about}</p>
      <p>{details.education}</p>
      <p>{details.contact}</p>
    </div>
  );
};

export default DoctorDetails;
