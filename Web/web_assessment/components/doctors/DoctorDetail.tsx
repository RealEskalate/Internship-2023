import { useRouter } from 'next/router';
import { useFetchDoctorProfileQuery } from '@/store/features/doctors/doctor-api';
import Image from 'next/image';
import React from 'react';

const DoctorDetail = () => {
  const router = useRouter();
  const { id } = router.query;
  console.log(id);

  const { data: doctorProfile = [], isFetching } = useFetchDoctorProfileQuery({ id: id || '' });
  if (!doctorProfile || isFetching) {
    return <div>Loading...</div>;
    console.log(doctorProfile);
  }

  const { photo, fullName, summary, speciality, institutionID_list } = doctorProfile;

  return (
    <div className="flex flex-col items-center justify-center w-full h-full p-4 bg-white rounded-lg shadow-md">
      <div className="flex items-center justify-center w-16 h-16 mb-4 rounded-full border-2 border-blue-500 bg-gradient-to-br from-blue-500 to-blue-600">
        <Image
          className="object-cover w-full h-full rounded-full"
          src={photo}
          alt={fullName}
          width={64}
          height={64}
        />
      </div>
      <h2 className="mb-2 text-xl font-semibold text-black">{fullName}</h2>
      <p className="text-sm text-gray-700">{summary}</p>
      <p className="text-sm text-gray-300 bg-blue-500 rounded-full px-3 py-1">{speciality[0].name}</p>
      <p className="text-sm text-gray-700">{institutionID_list[0].institutionName}</p>
    </div>
  );
};

export default DoctorDetail;
