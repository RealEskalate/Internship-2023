import React, { useEffect } from "react";
import { useGetDoctorsQuery } from "../../store/features/doctors/doctor-api";

const DoctorsList = () => {
  const { data: doctors = [], isLoading, isError } = useGetDoctorsQuery();
  console.log(doctors);

  useEffect(() => {}, []);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error while fetching doctors data.</div>;
  }
  const data = doctors.data;
  return (
    <div>
      <h2>Doctor List</h2>
      {data.map((doctor: any) => (
        <div key={doctor.id} className="border rounded p-4 mb-4">
          <div className="flex items-center mb-2">
            <img
              src={data.photoUrl}
              alt="Doctor"
              className="w-16 h-16 rounded-full mr-4"
            />
            <div>
              <h3 className="text-lg font-bold">{data.name}</h3>
              <p className="text-gray-500">{data.specialty}</p>
            </div>
          </div>
          <p className="text-gray-600">Institution: {data.institutionName}</p>
        </div>
      ))}
    </div>
  );
};

export default DoctorsList;
