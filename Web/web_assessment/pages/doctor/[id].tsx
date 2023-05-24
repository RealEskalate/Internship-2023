import React from 'react';
import { useRouter } from 'next/router';
import { useGetDoctorProfileQuery } from '@/store/features/doctor/doctor-api';

const DoctorDetailPage: React.FC = () => {
  const router = useRouter();
  const { id } = router.query;
  const { data: doctorProfile = [], isLoading, isError } = useGetDoctorProfileQuery(id as string);

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
    <div className='m-16'>
      <div className="flex items-center mt-4">
        <img src={doctorProfile.photo} alt={doctorProfile.fullName} className="mx-auto w-48 h-48 rounded-full" />
        </div>
        <div className='grid grid-cols-5'>
        <div className="col-span-4 grid grid-cols-2">
          <div className='col-span-1'>
          <h1 className="text-xl ">{doctorProfile.fullName}</h1>
          <p className="text-gray-500">{doctorProfile.speciality[0].name}</p>
          </div>
          <div className='col-span-1'>
            <p>
              {doctorProfile.institutionID_list[0].address.region}
            </p>
          </div>
          <div>
            <h1>
              About
            </h1>
            <p>
              {doctorProfile.summary}
            </p>
          </div>
          
          {/* Additional doctor details */}
        </div>
        </div>
        
    
    </div>
  );
};

export default DoctorDetailPage;