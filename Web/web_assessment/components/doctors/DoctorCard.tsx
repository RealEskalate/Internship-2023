import { Doctor } from "@/types/doctors";
import Image from "next/image";
import React from "react";

const DoctorCard = ({
  photo,
  fullName,
  mainInstitution,
  speciality,
}: Doctor) => {
  return (
    <div className="w-72 p-10 shadow-lg flex flex-col gap-3 items-center">
      <Image
        src={photo}
        alt="profile-pic"
        className="inline object-cover self-center w-16 h-16 mr-2 rounded-full border-4 border-purple-600"
        width={120}
        height={120}
      />
      <p>{fullName}</p>
      <p className="bg-purple-600 px-3 py-1 rounded-2xl">
        {speciality[0].name}
      </p>
      <p>{mainInstitution.institutionName}</p>
    </div>
  );
};

export default DoctorCard;
