import { useGetDoctorQuery } from '@/store/features/doctors/doctor-api'
import React from 'react'

const DoctorDetailPage = () => {
    const { data: doctor, isLoading , isSuccess, isError, error} = useGetDoctorQuery("62b959bf23006348f0f44b53")


    if (isLoading){
      return <div>Loading...</div>
    } else if (error || !doctor || !isSuccess || isError) {
      return <div>Error doctorLength:{doctor} error:{error ? error.toString() : ""}</div>
    }
  return (
    <div>[id]</div>
  )
}

export default DoctorDetailPage