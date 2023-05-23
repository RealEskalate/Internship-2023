import React from 'react';
import { useRouter } from  'next/router';
import { useGetDoctorProfileQuery } from '@/store/features/doctors/doctors-api';

const DoctorProfile: React.FC = () => {
  const router = useRouter();
  const id = router.query.id as string;
  const { data: doctor, isLoading, isError } = useGetDoctorProfileQuery(id);
 
  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error fetching todo</div>;
  }

  if (!doctor) {
    return <div>Todo not found</div>;
  }
  return (
    <div className="doctor-card">
      <div className="doctor-photo">
        <img src={doctor.fullName} alt={doctor.fullName} />
      </div>
      <div className="doctor-details">
        <h2>{doctor.fullName}</h2>
        
      </div>
    </div>
  );
  
};
export default DoctorProfile