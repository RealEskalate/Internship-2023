import { useGetDoctorsQuery, useSearchDoctorQuery } from '@/store/hakim-list/hakim-list-api';
import React, { useState } from 'react'
import DoctorCard from './DoctorCard';
import { useRouter } from 'next/router';

const DoctorsList: React.FC = () =>{
    const { data: doctors, error, isLoading } = useGetDoctorsQuery();
    const [search, setSearch] = useState("")
    const router = useRouter();

    const handleCardClick = (id:string) => {
      router.push(`/doctordetail/${id}`);
    };
    const searchHanlder = (name:string) =>{
      const {data:searchResult , error, isLoading} = useSearchDoctorQuery(name)

    }



    if (isLoading) {
      return <div>Loading...</div>;
    }
  
    if (error) {
      return <div>Error: {error.message}</div>;
    }
  return (
    <div className = "grid grid-cols-4 gap-2 p-8">
    
      {
        doctors?.data?.map((doctor) => {
          return (
            <div key = {doctor._id} onClick = {() => handleCardClick(doctor._id)}>
              <DoctorCard singleDoctor={doctor} />
            </div>
          )
        }

        )
      }
    </div>
  )
}

export default DoctorsList