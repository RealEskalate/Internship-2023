// DoctorList.tsx

import React, { useEffect } from 'react';
import { useFetchDoctorsMutation } from '../api-slice/doctors-api';
import DoctorCard from './DoctorCard';

const DoctorList: React.FC = () => {
  const [fetchDoctors, { data, isLoading, isError }] = useFetchDoctorsMutation();

  useEffect(() => {
    const fetchData = async () => {
      try {
        const postData: any = {
          // Provide any necessary data for the post request
        };

        await fetchDoctors(postData);
      } catch (error) {
        // Handle the error
        console.error(error);
      }
    };

    fetchData();
  }, [fetchDoctors]);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error occurred while fetching data.</div>;
  }
  return (
    <div className="grid grid-cols-1 gap-4 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4">
      {Array.isArray(data) && data.map((doctor) => (
        <DoctorCard key={doctor._id} doctor={doctor} />
      ))}
      
    </div>
  
  );
};

export default DoctorList;
