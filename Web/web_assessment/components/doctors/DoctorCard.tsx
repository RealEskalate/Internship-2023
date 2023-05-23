import React from 'react';
import {Doctor} from "@/types/doctor";

export type DoctorCardProp = {
    doctor: Doctor,
    onClick: (id: string) => void
}

const DoctorCard: React.FC<DoctorCardProp> = ({ doctor: { _id, fullName, speciality, photo, mainInstitution }, onClick }: DoctorCardProp) => {
    return (
        <div onClick={() => onClick(_id)} className="flex flex-col items-center justify-center p-4 bg-white rounded-lg shadow-lg">
            <div className="w-24 h-24 rounded-full overflow-hidden">
                <img className="w-full h-full object-cover" src={photo} alt="Person" />
            </div>
            <div className="mt-4 text-center">
                <h3 className="text-xl font-bold mb-2">{fullName}</h3>
                <p className="text-gray-500 mb-1">
                    <span className="bg-indigo-500 text-white px-2 py-1 rounded-md">{speciality[0].name}</span>
                </p>
                <p className="text-gray-500 mb-2">{mainInstitution.institutionName}</p>
            </div>
        </div>
    );
};

export default DoctorCard;