import React, { useState, useEffect } from "react";
import DoctorCard from "./DoctorCard";
import { useGetDoctorsQuery } from "@/store/features/doctors/doctors-api";
import { Content } from "next/font/google";
import Error from "../common/Error";
import { Doctor } from "@/types/doctors";
import Search from "../common/Search";
import { useRouter } from 'next/router';

const DoctorsList: React.FC = () => {
    const [keyWord, setKeyWord] = useState<string>('')
    const router = useRouter()

     let {
        data: response,
        isLoading,
        isSuccess,
        isError,
        error,
      } = useGetDoctorsQuery(keyWord)
    
      let content
      useEffect(() => {
    
      }, [keyWord])

      const openProfile = (id: string) => {
        router.push(`doctors/${id}`)
      }
      if (isLoading) {
        content = (
            <div>
            <Search setKeyWord={setKeyWord} keyWord={keyWord} ></Search>
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3  justify-items-center items-center gap-0 p-16">
            {Array(3)
              .fill(0)
              .map((_, index) => (
                <div
                  key={index}
                  className="animate-pulse flex flex-col self-start bg-white rounded-lg p-6 m-2 items-center justify-center shadow-xl w-[400px]"
                >
                  <div className="rounded-full w-32 h-32 mt-2 bg-gray-200 object-contain"></div>
                  <div className="w-1/2 h-5 bg-gray-200 m-3"></div>
                  <div className="w-1/3 h-5 bg-gray-200"></div>
                  <div className="flex flex-col my-4 p-4 w-full gap-3">
                    <div className="w-full h-5 bg-gray-200"></div>
                    <div className="w-full h-5 bg-gray-200"></div>
                    <div className="w-full h-5 bg-gray-200"></div>
                    <div className="w-full h-5 bg-gray-200"></div>
                  </div>
                </div>
              ))}
          </div>
          </div>
        )
      } else if (isSuccess) {
        const doctors = response?.data
        content = (

            <div>
                <Search setKeyWord={setKeyWord} keyWord={keyWord} ></Search>
                <div className="justify-items-center items-center mx-auto gap-0 grid grid-cols-1 md:w-[90%] md:grid-cols-2 lg:grid-cols-4 ">
            {doctors?.map((doctor: Doctor, index: number) => {
               return <div onClick={() => openProfile(doctor._id)}><DoctorCard key={index} _id={doctor._id} fullname={doctor.fullName} photo={doctor.photo} speciality={doctor.speciality[0].name} hospital={doctor.mainInstitution.institutionName}></DoctorCard> </div>;
              })}
          </div>
            </div>
            
        )
      } else if (isError) {
        content = <Error error={"error fetching data"}></Error>
      }
    
  return (
    <div className="">
        {content}
    </div>
  );
};

export default DoctorsList;
