import React from 'react';
import { useGetDoctorsQuery } from '@/store/features/doctors/doctors-api';
import DoctorCard from './DoctorCard'
import SearchBar from './SearchBar'
const DoctorsList: React.FC = () => {
  const { data: response, isLoading, isError } = useGetDoctorsQuery('');
  const doctors = response?.data;
  
  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error loading doctors</div>;
  }
  
    return (
      
      <div>
        <SearchBar/>
        {Array.isArray(doctors) && doctors.map((doctor:any) => (
    <DoctorCard key= {doctor._id} id = {doctor._id} photoUrl={doctor.photo} name={doctor.fullName} specialty="pedrasan" address="addis ababa"/>
  ))}
      </div>
    );
  
};

export default DoctorsList;
