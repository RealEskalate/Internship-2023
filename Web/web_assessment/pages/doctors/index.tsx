import React, { useEffect } from 'react'
import Search from '@/components/doctors/Search'
import DoctorCard from '@/components/doctors/DoctorCard'
import { useGetDoctorsQuery } from '@/store/features/doctors/doctors-api'

const Doctors: React.FC = () => {
  const { data: doctors = [], isLoading , isSuccess, isError, error} = useGetDoctorsQuery("")


  if (isLoading){
    return <div>Loading...</div>
  } else if (error || !doctors || !isSuccess || isError) {
    return <div>Error doctorLength:{doctors} error:{error ? error.toString() : ""}</div>
  }
  return (
    <div className='flex flex-col items-center mx-2'>
        <Search />
        <div className="flex flex-wrap gap-4 items-center self-center">
        {doctors.data.map((doctor : any, index : number) => (
        <DoctorCard
          key={index}
          id={doctor._id}
          name={doctor.fullName}
          photo={doctor.photo}
          specialty={doctor.specialty ? doctor.specialty[0].name : ''}
          institution={doctor.institutionID_list[0].institutionName}
        />
      ))}</div>
    </div>
  )
}

export default Doctors