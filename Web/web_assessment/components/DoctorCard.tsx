import React from 'react';

interface DoctorCardProps {
  doctor: Doctor;
}



const DoctorCard: React.FC<DoctorCardProps>  = ({ doctor }) => {
  const { fullName, photo, summary, mainInstitution } = doctor;

  return (
    <div className="w-72 bg-white rounded-lg overflow-hidden shadow-md">
      <div className="h-32 bg-white rounded-t-lg flex items-center justify-center">
        <img
         className="w-32 h-32 bg-gray-300 rounded-full"
          src="./doctor-image"
          alt=""
        />
      </div>
      <div className="p-4">
        <h1 className="text-xl font-bold mb-2">Dr. Kalab Yilma</h1>
        <h2 className="text-gray-500 text-sm mb-4">Physician</h2>
        <p className="text-gray-700">
          Doctor
        </p>

      </div>
    </div>
  );
};

export default DoctorCard;


// // DoctorCard.js


// import React from 'react';

// interface DoctorCardProps {
//   doctor: Doctor;
// }



// const DoctorCard: React.FC<DoctorCardProps>  = ({ doctor }) => {
//   const { fullName, photo, summary, mainInstitution } = doctor;

//   return (
//     <div className="w-72 bg-white rounded-lg overflow-hidden shadow-md">
//       <div className="h-32 bg-white rounded-t-lg flex items-center justify-center">
//         <img
//          className="w-32 h-32 bg-gray-300 rounded-full"
//           src={doctor.photo}
//           alt="Profile Picture"
//         />
//       </div>
//       <div className="p-4">
//         <h1 className="text-xl font-bold mb-2">{doctor.fullName}</h1>
//         <h2 className="text-gray-500 text-sm mb-4">{doctor.summary}</h2>
//         <p className="text-gray-700">
//           {doctor.summary}
//         </p>

//       </div>
//     </div>
//   );
// };

// export default DoctorCard;


// // import React from 'react';

// // interface DoctorCardProps {
// //   doctor: Doctor;
// // }

// // const DoctorCard: React.FC<DoctorCardProps> = ({ doctor }) => {
// //   return (
// //     <div className="card">
// //       <img src={doctor.photo} alt={doctor.fullName} />
// //       <h3>{doctor.fullName}</h3>
// //       <p> Hello </p>
     
// //     </div>
// //   );
// // };

// // export default DoctorCard;
