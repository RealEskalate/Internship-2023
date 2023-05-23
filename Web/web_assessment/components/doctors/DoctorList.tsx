import { useGetDoctorsQuery } from '@/store/features/doctors/doctor-api';
import React from 'react'
import { Doctor } from '@/types/doctor/doctor';
import DoctorItem from './DoctorItem';
import { isFSA } from '@reduxjs/toolkit/dist/createAction';

const DoctorList = () => {
    const { data:doctorList = [], isFetching } = useGetDoctorsQuery({name: ''});
    console.log(doctorList);
    // doctorList is an array of doctor

    if (!doctorList || isFetching){
        return <div>loading...</div>
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