import React from "react";
import { Doctor } from "../../types/doctor";

interface DoctorsDetailProps {
  doctor: Doctor;
}

const DoctorsDetail: React.FC<DoctorsDetailProps> = ({ doctor }) => {
  const { photo, fullName, phoneNumbers, emails, summary, institutionID_list } =
    doctor;

  return (
    <div className="w-screen mx-auto p-6 bg-white rounded-lg shadow-md">
      <div className="relative flex justify-center mb-8">
        <div className="w-full h-60 bg-purple-500"></div>
        <div className="absolute bottom-0 left-1/2 transform -translate-x-1/2">
          <div className="w-80 h-80 rounded-full bg-white border-4 border-white -mb-40">
            <img
              src={photo}
              alt="Doctor"
              className="w-72 h-72 rounded-full mx-auto"
            />
          </div>
        </div>
      </div>
      <div className="flex justify-start">
        <div className="w-1/2">
          <h2 className="text-2xl font-bold text-black mb-4">{fullName}</h2>
          <div className="mb-4">
            <strong className="text-black">Phone Numbers:</strong>
            <ul>
              {phoneNumbers.map((phoneNumber, index) => (
                <li key={index} className="text-black">
                  {phoneNumber}
                </li>
              ))}
            </ul>
          </div>
          <div className="mb-4">
            <strong className="text-black">Emails:</strong>
            <ul>
              {emails.map((email, index) => (
                <li key={index} className="text-black">
                  {email}
                </li>
              ))}
            </ul>
          </div>
          <div className="mb-4">
            <strong className="text-black">About:</strong>
            <p className="text-black">{summary}</p>
          </div>
          <div>
            <strong className="text-black">Institutions:</strong>
            <ul>
              {institutionID_list.map((institution, index) => (
                <li key={index} className="text-black">
                  {institution}- {institution}
                </li>
              ))}
            </ul>
          </div>
        </div>
      </div>
    </div>
  );
};

export default DoctorsDetail;
