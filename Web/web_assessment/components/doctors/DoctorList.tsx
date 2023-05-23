import { useGetDoctorsQuery } from '@/store/features/doctors/doctor-api';
import React from 'react'
import { Doctor } from '@/types/doctor/doctor';
import DoctorItem from './DoctorItem';
import { isFSA } from '@reduxjs/toolkit/dist/createAction';

const DoctorList = () => {
    const { data:doctorList = [], isFetching } = useGetDoctorsQuery({name: ''});
    console.log(doctorList);

    if (!doctorList || isFetching){
        return (
          <div className=" h-screen flex justify-center items-center">
            <div
              className="inline-block h-8 w-8 animate-spin rounded-full border-4 border-solid border-current border-r-transparent align-[-0.125em] motion-reduce:animate-[spin_1.5s_linear_infinite]"
              role="status"
            >
              <span className="!absolute !-m-px !h-px !w-px !overflow-hidden !whitespace-nowrap !border-0 !p-0 ![clip:rect(0,0,0,0)]">
                Loading...
              </span>
            </div>
          </div>
        )
      }
    console.log(doctorList.data);
 

    return (
        <div className="grid grid-cols-1 gap-4 md:grid-cols-2 lg:grid-cols-4 xl:grid-cols-4">
        {doctorList.data.map((doctor: Doctor) => (
          <div key={doctor._id} className="grid-row-span-1">
            <DoctorItem {...doctor} />
          </div>
        ))}
      </div>
    );
}



export default DoctorList