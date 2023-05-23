import { useRouter } from 'next/router';
import { useFetchDoctorProfileQuery } from '@/store/features/doctors/doctor-api';
import Image from 'next/image';
import React from 'react';
import { institutionID_list } from '@/types/doctor/doctor';
import { useAppSelector } from '@/hooks/hooks';

const DoctorDetail = () => {
  const { doctorId:id } = useAppSelector((state)=>state.doctorId)
  const router = useRouter();
  console.log(id);

  const { data: doctorProfile = [], isFetching } = useFetchDoctorProfileQuery(id);
  if (!doctorProfile || isFetching) {
    console.log(id);
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
    <div className="flex flex-col w-full h-full p-4 bg-white rounded-lg shadow-md">
      <div className="flex items-center justify-center w-16 h-16 mb-4 rounded-full border-2 border-blue-500 bg-gradient-to-br from-blue-500 to-blue-600">
        <Image
          className="object-cover h-full rounded-full"
          src={photo}
          alt={fullName}
          width={100}
          height={100}
        />
      </div>
      <h2 className="mb-2 text-xl font-semibold text-black">{fullName}</h2>
      <p className="text-sm text-gray-700">{summary}</p>
      {speciality.length > 0 ? (
        <p className="text-sm text-gray-300">{speciality[0].name}</p>
      ) : (
        <p className="text-sm text-gray-300">No speciality data available</p>
      )}
      <h2 className=' font-bold mt-10'>
        About:
      </h2>
      <p>
      Lorem, ipsum dolor sit amet consectetur adipisicing elit. Ex, laborum quisquam hic perspiciatis fugiat beatae praesentium eligendi iusto accusamus voluptatem officiis eveniet perferendis enim quidem voluptates nihil nulla expedita quae?

      </p>
     {institutionID_list.length > 0 ? (
  institutionID_list.map((institution:institutionID_list, index:number) => (
    <p key={index} className="text-sm text-gray-700">{institution.institutionName}</p>
  ))
) : (
  <p className="text-sm text-gray-700">No institution data available</p>
)}
<h2 className='font-bold mt-10'>Eductaion</h2>
<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Voluptatum ab debitis iusto adipisci aliquid harum reiciendis enim ex molestiae animi nam ratione ipsa, illo voluptatem odio minima dolores omnis! Consequatur!</p>
<h2 className='font-bold mt-10'>contact info</h2>
<p>Lorem ipsum dolor sit amet consectetur adipisicing elit. Quisquam, voluptatum.</p>
    </div>
  );
};

export default DoctorDetail;
