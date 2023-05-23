import React, { useEffect } from 'react';
import { useGetDoctorByIdQuery } from '@/store/hakim-list/hakim-list-api';
import { useRouter } from 'next/router'
import Image from 'next/image'
const DoctorCard: React.FC = () => {
    const router = useRouter();
    const  id = router.query.id as string;
    const { data: doctor, error, isLoading } = useGetDoctorByIdQuery(id)



  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error: {error.message}</div>;
  }

  return (
    <div className = "flex flex-col">
      <div className = " w-1/2 pr-20 rounded-full relative items-center justify-center justify-self-end self-end mb-14 ">
            <Image className = "object-contain rounded-full border-4 border-primary" width={100} height = {100} src={doctor?.photo} alt='doctor'></Image>
            </div>
      <div className = "w-1/2 pl-10">
      <div className = "flex justify-between mb-10">

      <div>
      <p  className = "text-lg font-bold">{doctor?.fullName}</p>
      <p className = "text-lighttext">{doctor?.speciality[0].name}</p>
      </div>
      <div className = "text-right">
        <p>Addis ababa university</p>
        <p className = "text-lg">wahsigton meedical center</p>

      </div>
      </div>

      <p>About</p>
      <p>loremlertm Lorem ipsum dolor sit amet consectetur adipisicing 
        elit. Quas, blanditiis odio! Qui atque iure, incidunt, dolorem, 
        cupiditate vel voluptatum amet quo ipsum facilis pariatur fugit
         porro quis illum corporis dicta.</p>

      <p>education</p>
      <div>
        <div>
          <p>{doctor?.education}</p>
        </div>
        <div>
          <p>2003 2007</p>
        </div>

      </div>
      <p>contanct info</p>
      <p>phone number</p>
      <p>2o3uo2i3u</p>
      <p>email</p>
      <p>{doctor?.emails}</p>
      </div>
    </div>
  );
};

export default DoctorCard;