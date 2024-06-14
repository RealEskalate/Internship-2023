import React from 'react';
import { Doctor } from '@/types/doctor'; // Assuming you have the Doctor type defined in a separate file

interface DoctorDetailProps {
  doctor: Doctor;
}

const DoctorDetail: React.FC<DoctorDetailProps> = ({ doctor }) => {
  const {
    photo,
    fullName,
    speciality,
    institutionID_list,
    summary,
    education,
    emails,
  } = doctor;

  return (
    <div className="flex-col items-center">
    <div className="flex flex-col  gap-8 justify-center">
      {/* Profile Image */}
      <div>
        <img src={photo} alt="Profile" className="w-40 h-40 rounded-full" />
      </div>

      {/* Name and Speciality */}
      <div className="flex flex-col justify-center w-full">
        <h2 className="text-2xl font-bold mb-2">{fullName}</h2>
        <p className="text-lg text-gray-600 mb-4">{speciality[0].name}</p>
      </div>

      {/* Institution and Medical Center */}
      <div className="flex flex-col justify-center w-full">
        <p className="text-lg mb-2">{institutionID_list[0].institutionName}</p>
        <p className="text-lg">{institutionID_list[0].institutionType}</p>
      </div>

      {/* About the Doctor */}
      <div className="w-full">
        <h3 className="text-xl font-bold mb-2">About</h3>
        <p>{summary}</p>
      </div>

      {/* Education */}
      <div className="w-full">
        <h3 className="text-xl font-bold mb-2">Education</h3>
        <ul className="list-disc pl-4">
          {education.map((edu, index) => (
            <li key={index} className="mb-2">
              <p>{edu.university}</p>
              <p>{edu.fieldOfStudy}</p>
              <p>{edu.duration}</p>
            </li>
          ))}
        </ul>
      </div>

      {/* Contact Info */}
      <div className="w-full">
        <h3 className="text-xl font-bold mb-2">Contact Info</h3>
        <p>Email: {emails[0]}</p>
        {/* Add phone number here if available */}
      </div>
    </div>
    </div>
  );
};

export default DoctorDetail;
