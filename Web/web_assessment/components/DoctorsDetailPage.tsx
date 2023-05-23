import { useParams } from 'react-router-dom';
import { DoctorDetail } from '../types/doctor'
import { FC } from 'react';
import Image from 'next/image';

interface DoctorDetailsPageProps {
  doctor: DoctorDetail;
}

const DoctorDetailsPage: FC<DoctorDetailsPageProps> =  ({doctor}) => {
  const { id } = useParams();
  return (
    <div>
      <div className=" absolute w-227 h-227 left-567 top-390 border-5 border-solid border-purple-600 ">
        <Image src={doctor?.image} alt="Doctor Image" width={90} height={80} />
      </div>
      <h2 className='"absolute w-229 h-48 left-126 top-657 font-poppins font-semibold text-2xl leading-12 text-black"'>{doctor?.name}</h2>
      <p className="absolute w-179 h-32 left-126 top-705 font-poppins font-light text-lg leading-8 text-gray-700">{doctor?.career}</p>
      <p className="absolute w-278 h-30 left-581 top-705 font-poppins font-normal text-base leading-8 text-center text-gray-600">{doctor?.placeOfWork}</p>
      <p className="absolute w-721 h-141 font-poppins font-normal text-base leading-6 text-justify text-black">{doctor?.About.detail}</p>
      <p className="absolute w-180 h-33 font-poppins font-normal text-base leading-6 text-justify text-black opacity-71">{doctor?.Education.detail}</p>
      <p className="w-115 h-27 font-poppins font-bold text-base leading-6 text-black flex-none">{doctor?.contactInfo.title}</p>
      <p className="absolute w-142 h-20 left-164 top-1449 font-poppins font-bold text-base leading-5 tracking-widest capitalize text-iris-80" >{doctor?.contactInfo.phonenumber}</p>
      <p className="absolute w-163 h-21 left-164 top-1586 font-poppins font-normal text-sm leading-5 text-gray-700">{doctor?.contactInfo.email}</p>
    </div>
  );
};

export default DoctorDetailsPage;
