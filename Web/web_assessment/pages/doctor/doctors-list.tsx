import React from 'react';
import { useGetDoctorsQuery} from '@/store/features/doctor/doctor-api';
import Image from 'next/image';

const DoctorListPage: React.FC = () => {
  const { data: doctors = {}, isLoading, isError } = useGetDoctorsQuery();
    console.log(doctors)
    console.log(doctors.data)
    const datas = doctors.data
  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error occurred while fetching doctors.</div>;
  }

  return (
    <div>
      {
  
      <div className='mt-8'>
      
      <div className="grid grid-cols-1 gap-4 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4">
        {datas.map((doctor:any) => (
          <div key={doctor._id} className="bg-white p-4 rounded-lg shadow ml-4 mr-4">
            <div className="flex justify-center">
              <img src={doctor.photo} alt={doctor.message} className="w-24 h-24 rounded-full"  />
            </div>
            <h2 className="text-xl font-bold mt-4 mx-auto flex justify-center">{doctor.fullName}</h2>
            <div className='flex justify-center'>
            <button className="text-center px-4 py-2 bg-blue-400">{doctor.speciality[0].name}</button>
            </div>
            <p className="text-center"> {doctor.institutionID_list[0].institutionName} </p>
   
          </div>
        ))}
      </div>
    </div>
  
      }
      
    </div>
  );
};

export default DoctorListPage;
