import React from 'react';
import Link from 'next/link';
import { MdPlace } from 'react-icons/md';
import { FaPhone } from 'react-icons/fa';
import { MdEmail } from 'react-icons/md';
import { Datum } from '../../types/Hospital';

interface HospitalCardProps {
  hospital: Datum;
}

const HospitalCard: React.FC<HospitalCardProps> = ({ hospital }) => {
  return (
    <div className="hospital-card">
      <div className="hospital-image">
        <img src={hospital.coverPhoto} alt="Hospital" />
      </div>
      <div className="hospital-info">
        <div className="hospital-location">
          <MdPlace />
          <span>{hospital.summary}</span>
        </div>
        <h2 className="hospital-name">{hospital.institutionName}</h2>
        {/* Display the distance away information */}
        <p className="hospital-distance">Distance: 3 kilometeres Away</p>
        <div className="hospital-contact">
          <FaPhone />
          <span>{hospital.phoneNumbers[0]}</span>
        </div>
        <p className="hospital-status">Status: {hospital.status}</p>
      </div>
    </div>
  );
};

export default HospitalCard;