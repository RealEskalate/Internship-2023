import React from 'react';
import { useRouter } from 'next/router';
import { useFetchDoctorsQuery } from '../../api-slice/doctors-api';
import DoctorDetails from '../../components/DoctorDetails';
// import { DoctorDetails } from '../../types';

const DoctorDetailsPage: React.FC = () => {
  const router = useRouter();
  const { doctorId } = router.query;

  const { data: doctorDetails, isLoading } = useFetchDoctorsQuery(doctorId as string);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <DoctorDetails details={doctorDetails as DoctorDetails} />
    </div>
  );
};

export default DoctorDetailsPage;
