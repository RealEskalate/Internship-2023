// DoctorCard.js

import React from 'react';

interface DoctorCardProps {
  doctor: Doctor;
}

const DoctorCard: React.FC<DoctorCardProps> = ({ doctor }) => {
  return (
    <div className="card">
      <img src={doctor.photo} alt={doctor.fullName} />
      <h3>{doctor.fullName}</h3>
      <p>{doctor.birthday}</p>
     
    </div>
  );
};

export default DoctorCard;
