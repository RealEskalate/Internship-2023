import React from "react";
import { DoctorData, Speciality } from "../../types/doctor";
import Image from "next/image";
import Link from "next/link";
import "tailwindcss/base.css";


interface DoctorCardProps {
  doctor: DoctorData;
}



const DoctorCard: React.FC<DoctorCardProps> = ({ doctor }) => {
  return (
    // <Link href={`./detail/${doctor._id}`} passHref>
      <Link href={`./doctor-detail`} passHref>
      <div className="rounded-lg shadow-xl bg-white p-4 mt-9 mb-9">
        <div className="ml-20">
          <Image
            src={doctor.photo}
            alt={""}
            width={50}
            height={50}
            className={`rounded-full object-cover `}
          />
        </div>
        <div className="ml-11 mt-5">
          <h3>{doctor.fullName}</h3>
        </div>
        <div>
          {doctor.summary}
        </div>
        <div>
        {doctor.speciality.map((special: Speciality) => (
              <div className=" ml-11 ">
                <button
                  key={doctor._id}
                  className="btn btn-outline btn-pill flex mr-2 mb-2 mx-4 mt-5 px-4 py-2 bg-violet-800 rounded-full"
                >
                  <i>
                    <span className="text-lg font-semibold text-white">
                      {special.name}
                    </span>
                  </i>
                </button>
              </div>
            ))}
        </div>
       
      </div>
    </Link>
  );
};

export default DoctorCard;
