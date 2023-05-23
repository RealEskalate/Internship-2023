import React, { useState } from 'react';
import { useGetDoctorsQuery, useSearchDoctorsQuery} from '@/store/features/doctor/doctor-api';
import Image from 'next/image';

const DoctorListPage: React.FC = () => {
  const { data: doctors = {}, isLoading, isError } = useGetDoctorsQuery();
  const [searchQuery, setSearchQuery] = useState('');

  const { data: searchedDoctors } = useSearchDoctorsQuery({ keyword: searchQuery });

  const handleSearch = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchQuery(event.target.value);
  };

    const datas = doctors.data
  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error occurred while fetching doctors.</div>;
  }

  return (
    <div className='bg-white'>
      {
  
      <div className=''>
      <div className=" flex justify-center mx-auto focus:border-none">
        <input
          type="text"
          placeholder="Search by name"
          value={searchQuery}
          onChange={handleSearch}
          className="p-2 border border-gray-300 focus:border-none rounded-xl mb-8 w-96 mt-8"
        />
      </div>
      <div className="grid grid-cols-1 gap-4 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4">
        {(searchQuery ? searchedDoctors : datas)?.map((doctor:any) => (
          <div key={doctor._id} className="bg-white p-4 rounded-lg ml-4 mr-4 shadow-2xl">
            <div className="flex justify-center">
              <img src={doctor.photo} alt={doctor.message} className="w-24 h-24 rounded-full"  />
            </div>
            <h2 className="text-xl font-bold mt-4 mx-auto flex justify-center">{doctor.fullName}</h2>
            <div className='flex justify-center'>
            <button className="text-center px-4 py-2 bg-indigo-500 rounded-xl">{doctor.speciality[0].name}</button>
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
