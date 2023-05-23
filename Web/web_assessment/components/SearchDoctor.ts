// import React, { useState } from 'react';
// import { useGetDoctorsQuery } from './../store/doctor/doctorapi';

// const DoctorSearch = () => {
//   const [searchTerm, setSearchTerm] = useState('');

//   const { data, isLoading, isError } = useGetDoctorsQuery(searchTerm);

//   const handleSearchChange = (event: { target: { value: React.SetStateAction<string>; }; }) => {
//     setSearchTerm(event.target.value);
//   };

//   return (
//     <div>
//       <input type="text" value={searchTerm} onChange={handleSearchChange} />
//       {isLoading && <div>isLoading...</div>}
//       {isError && <div>Error</div>}
//       {data && (
//         <ul>
//           {data.map((doctor) => (
//             <li key={doctor.id}>{doctor.name}</li>
//           ))}
//         </ul>
//       )}
//     </div>
//   );
// };

// export default DoctorSearch;