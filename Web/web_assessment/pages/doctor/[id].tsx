import React from 'react';
import { useRouter } from 'next/router';
import { useGetDoctorProfileQuery } from '@/store/features/doctor/doctor-api';

const DoctorDetailPage: React.FC = () => {
  const router = useRouter();
  const { id } = router.query;
  const { data: doctorProfile, isLoading, isError } = useGetDoctorProfileQuery(id as string);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error occurred while fetching doctor profile.</div>;
  }

  if (!doctorProfile) {
    return <div>Doctor not found.</div>;
  }

  return (
    <div>
      <h1 className="text-2xl font-bold">{doctorProfile.fullName}</h1>
      <div className="flex items-center mt-4">
        <img src={doctorProfile.photo} alt={doctorProfile.name} className="w-24 h-24 rounded-full" />
        <div className="ml-4">
          <p className="text-gray-500">Specialty: {doctorProfile.specialty}</p>
          <p className="text-gray-500">Email: {doctorProfile.email}</p>
          {/* Additional doctor details */}
        </div>
      </div>
    </div>
  );
};

export default DoctorDetailPage;