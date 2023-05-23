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
    return (
      <div className="h-screen flex justify-center items-center">
        <div className="inline-block h-8 w-8 animate-spin rounded-full border-4 border-solid border-current border-r-transparent align-[-0.125em] motion-reduce:animate-[spin_1.5s_linear_infinite]" role="status">
          <span className="!absolute !-m-px !h-px !w-px !overflow-hidden !whitespace-nowrap !border-0 !p-0 ![clip:rect(0,0,0,0)]">
            Loading...
          </span>
        </div>
      </div>
    );
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
      {speciality.length > 0 ? (
        <p className="text-sm text-gray-300 bg-blue-500 rounded-full px-3 py-1">{speciality[0].name}</p>
      ) : (
        <p className="text-sm text-gray-300">No speciality data available</p>
      )}
      {institutionID_list.length > 0 ? (
        <p className="text-sm text-gray-700">{institutionID_list[0].institutionName}</p>
      ) : (
        <p className="text-sm text-gray-700">No institution data available</p>
      )}
    </div>
  );
};

export default DoctorDetail;
