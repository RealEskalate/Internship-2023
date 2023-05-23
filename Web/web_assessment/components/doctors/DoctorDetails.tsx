import React from "react";
import { useGetDoctorsQuery } from "../../store/features/doctors/doctor-api";

const DoctorDetails: React.FC = () => {
  const { data, isLoading, isError } = useGetDoctorsQuery();

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error fetching doctor details.</div>;
  }

  const doctor = data?.[0];

  if (!doctor) {
    return <div>No doctor found.</div>;
  }

  const {
    photo,
    name,
    specialty,
    about,
    summary,
    contactInfo,
    phoneNumber,
    email,
  } = doctor;

  return (
    <div className="max-w-lg mx-auto p-4">
      <div className="flex justify-center mb-4">
        <img src={photo} alt={name} className="w-48 h-48 rounded-full" />
      </div>
      <h2 className="text-2xl font-bold mb-2">{name}</h2>
      <p className="text-lg text-gray-600 mb-4">{specialty}</p>
      <div className="mb-4">
        <h3 className="text-lg font-bold mb-2">About</h3>
        <p>{about}</p>
      </div>
      <div className="mb-4">
        <h3 className="text-lg font-bold mb-2">Summary</h3>
        <p>{summary}</p>
      </div>
      <div className="mb-4">
        <h3 className="text-lg font-bold mb-2">Contact Info</h3>
        <p>{contactInfo}</p>
        <p className="text-gray-600">Phone: {phoneNumber}</p>
        <p className="text-gray-600">Email: {email}</p>
      </div>
    </div>
  );
};

export default DoctorDetails;
