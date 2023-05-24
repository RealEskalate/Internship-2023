import { useGetDoctorsQuery } from "@/store/features/doctors/doctor-api";
import React, { useState } from "react";
import { Doctor } from "@/types/doctor/doctor";
import DoctorItem from "./DoctorItem";

const DoctorList = () => {
  const [name, setName] = useState("");
  const [name2, setName2] = useState("");
  const { data: doctorList = [], isFetching } = useGetDoctorsQuery(
    name2);

  if (!doctorList || isFetching) {
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
    );
  }
  const handleSubmit = (e: React.FormEvent<HTMLFormElement>) => {
    e.preventDefault();
    setName2(name);
    console.log(name2);
  };


  return (
    <div className="mt-10 flex flex-col min-h-screen">
      <div className="flex items-center justify-center mr-2 rounded-full">
       <form onSubmit={handleSubmit} className="w-full mx-20">
  <input
    value={name}
    onChange={(e) => setName(e.target.value)}
    className="w-full  px-8 h-10 text-sm mx-20 text-gray-700 placeholder-gray-200 border rounded-full focus:outline-none focus:border-primary"
    type="text"
    placeholder="Name, Specialty..."
  />
</form>
      </div>
      <div className="grid grid-cols-1 gap-4 md:grid-cols-2 lg:grid-cols-4 xl:grid-cols-4">
        {doctorList.data.map((doctor: Doctor) => (
          <div key={doctor._id} className="grid-row-span-1">
            <DoctorItem {...doctor} />
          </div>
        ))}
      </div>
    </div>
  );
};

export default DoctorList;
