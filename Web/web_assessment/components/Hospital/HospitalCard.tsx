import React from 'react';
import Image from 'next/image';
import Link from 'next/link';
import {Hospital} from "./../../types/hospital"

type HospitalCardProps = {
  hospital: Hospital;
};

const HospitalCard: React.FC<HospitalCardProps> = ({ hospital }) => {
  return (
    <Link href={`/profile/${hospital._id}`}>
      <div className="flex">
        <Image
          src={hospital.coverPhoto}
          alt="Image"
          width={300}
          height={50}
          className="object-cover object-center rounded-md w-1/3 bg-gray-100"
        />

        <div className="w-1/3 bg-gray-100 p-4">
          <div className="mb-4">
            <p className="text-gray-600">
              {hospital.address.summary}, {hospital.address.region}
            </p>
            <h2 className="text-xl font-bold mb-2">{hospital.institutionName}</h2>
            <p className="text-gray-600">
              {hospital.location.coordinates}, {hospital.location.type}
            </p>
          </div>
          <div className="flex-wrap">
            <p className="text-gray-600">Phone: {hospital.phoneNumbers}</p>
            <p className="text-gray-600">Email: {hospital.emails}</p>
          </div>
        </div>

        <div className="bg-gray-100 flex justify-end w-1/3">
          <div
            className={`bg-${hospital.status === 'Open' ? 'green' : 'red'}-500 rounded-full mx-2 h-1/6`}
          >
            {hospital.status}
          </div>
        </div>
      </div>
    </Link>
  );
};

export default HospitalCard;
