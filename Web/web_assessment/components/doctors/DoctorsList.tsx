import React, { useEffect } from "react";
import { useGetDoctorsQuery } from "../../store/features/doctors/doctor-api";

const DoctorsList = () => {
  const { data: doctors = [], isLoading, isError } = useGetDoctorsQuery();

  useEffect(() => {}, []);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error while fetching doctors data.</div>;
  }

  return (
    <div>
      <h2>Doctor List</h2>
      {doctors.map((doctor: any) => (
        <div key={doctor.id} className="border rounded p-4 mb-4">
          <div className="flex items-center mb-2">
            <img
              src={doctor.photoUrl}
              alt="Doctor"
              className="w-16 h-16 rounded-full mr-4"
            />
            <div>
              <h3 className="text-lg font-bold">{doctor.name}</h3>
              <p className="text-gray-500">{doctor.specialty}</p>
            </div>
          </div>
          <p className="text-gray-600">Institution: {doctor.institutionName}</p>
        </div>
      ))}
    </div>
  );
};

export default DoctorsList;
