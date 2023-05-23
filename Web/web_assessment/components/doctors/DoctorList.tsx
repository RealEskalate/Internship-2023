// import { useGetDoctorsQuery } from "../../store/features/doctors/doctors-api";
// import { DoctorData, Speciality } from "../../types/doctor";
// import DoctorCard from "./DoctorCard";

// // interface SpecialProps {
// //     speciallity: Speciality[];
// //   }

// //   const Special: React.FC<Speciality> = ({ name, _id }) => {
// //     return (

// //     );
// //   };

// const DoctorList: React.FC = () => {
//   const { data: doctors, isLoading, isError } = useGetDoctorsQuery({});

//   if (isLoading) {
//     return <div>Loading...</div>;
//   }

//   if (isError) {
//     return <div>Error occurred while fetching doctors.</div>;
//   }

//   return (
//     <div>
//       <h1>Doctor List</h1>
//       <ul>
//         {doctors.data.map((doctor: DoctorData) => (
//         //   <li key={doctor._id}>
//         //     <li>{doctor.emails}</li>

// <li>
//   {doctor.speciality.map((special: Speciality) => (
//     <li key={special._id}>{special.name}</li>
//   ))}
// </li>
//         //   </li>
//         <DoctorCard doctor={doctor} />
//         ))}
//       </ul>
//     </div>
//   );
// };

// export default DoctorList;

import React from "react";
import { useGetDoctorsQuery } from "../../store/features/doctors/doctors-api";
import { DoctorData, Speciality } from "../../types/doctor";
import DoctorCard from "./DoctorCard";

const DoctorList: React.FC = () => {
  const { data, isLoading, isError } = useGetDoctorsQuery({});
  console.log(data);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error occurred while fetching doctors.</div>;
  }

  const columns = 4; // Number of columns for doctors

  const chunkedDoctors = Array.from(
    { length: Math.ceil(data?.data?.length / columns) },
    (_, index) => data?.data?.slice(index * columns, (index + 1) * columns)
  );
  console.log(chunkedDoctors);

  return (
    <div>
      <div className="doctor-grid">
        {chunkedDoctors.map((doctorsPerColumn: DoctorData[], index) => (
          <div key={index} className="doctor-column">
            {doctorsPerColumn.map((doctor: DoctorData) => (
              <div key={doctor._id}>
                <DoctorCard key={doctor._id} doctor={doctor} />

               
              </div>
            ))}
          </div>
        ))}
      </div>
    </div>
  );
};

export default DoctorList;
