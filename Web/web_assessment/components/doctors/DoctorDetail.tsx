import { useRouter } from 'next/router';
import { useFetchDoctorProfileQuery } from '@/store/features/doctors/doctor-api';
import Image from 'next/image';
import React from 'react';
import { institutionID_list } from '@/types/doctor/doctor';
import { useAppSelector } from '@/hooks/hooks';

const DoctorDetail = () => {
  const { doctorId:id } = useAppSelector((state)=>state.doctorId)

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
 console.log(institutionID_list)
  return (
    <div className="flex flex-col w-full h-full p-4 bg-white rounded-lg shadow-md">
      <div className="relative">
        <div className="absolute w-full h-full bg-cover bg-center">
        <Image
            className="object-cover h-full"
            src="/images/Group 8823.png"
            alt={fullName}
            width={2000}
            height={700}
          />
        </div>
        <div className=" mt-24 relative z-10 w-full flex items-end justify-center  h-24">
          <Image
            className=" mt-10 object-cover h-full rounded-full border-4 border-blue-500"
            src={photo}
            alt={fullName}
            width={100}
            height={600}
          />
        </div>
      </div>
      <h2 className="mt-10 mb-2 text-xl font-semibold text-black">{fullName}</h2>
      <p className="text-sm text-gray-700">{summary}</p>
      {speciality.length > 0 ? (
        <p className="text-sm text-gray-800">{speciality[0].name}</p>
      ) : (
        <p className="text-sm text-gray-300">No speciality data available</p>
      )}
      <h2 className=' font-bold mt-10'>
        About:
      </h2>
      <p>
        {institutionID_list[0].lang.am.summary}

      </p>
     {institutionID_list.length > 0 ? (
  institutionID_list.map((institution:institutionID_list, index:number) => (
    <div key={index} className="flex justify-start gap-24 mt-10">
      <h1 className='font-bold'>Institution</h1>
      <p className="text-sm text-gray-700">{ institution.institutionName}</p></div>
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
