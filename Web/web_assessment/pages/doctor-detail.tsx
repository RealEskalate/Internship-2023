import Image from 'next/image'
import { Inter } from 'next/font/google'
import SingleDoctor from '@/components/doctors/SingleDoctor'
import { useGetDoctorsQuery } from '@/store/features/doctors/doctors-api'
import DoctorList from '@/components/doctors/DoctorList'


interface Doctor {
  id: string;
  name: string;
  specialty: string;
  // Add more properties as needed
}

interface DoctorParams {
  id: string;
}




const DoctorDetailPage: React.FC = () => {
//   const { id } = useParams<DoctorParams>();
//   const { data: doctor, isLoading, isError, error } = useGetDoctorsQuery();

//   useEffect(() => {
    // Fetch the doctor data
    // Pass the doctor ID as a parameter to the query
//     getDoctor();
//   }, [id]);

//   const getDoctor = async () => {
//     try {
      // Fetch the doctor data based on the ID
    //   await useGetDoctorsQuery(id);
    // } catch (error) {
      // Handle error
//     }
//   };

//   if (isLoading) {
//     return <div>Loading...</div>;
//   }

//   if (isError) {
//     return <div>Error: {error?.message}</div>;
//   }

//   if (!doctor) {
//     return <div>No doctor found.</div>;
//   }

// return (
//     <div>
//       <h2>Doctor Detail</h2>
//       <p>ID: {doctor.id}</p>
//       <p>Name: {doctor.name}</p>
//       <p>Specialty: {doctor.specialty}</p>
//       {/* Render more doctor details */}
//     </div>
//   );

return (
    <div className="min-h-screen bg-white font-{poppins} scroll-smooth self-center m-36 items-center">
        <div className='m-20 mt-11'>
            <br />
       <div className='items-center self-center ml-96'>
       <h2 className='mt-11'>Doctor Detail</h2>
        <h3>Photo</h3>
      <p>ID: 12</p>
       </div>
      <p>Name: name</p>
      <p>Specialty: speciality</p>
      <h3>Lorem ipsum dolor sit amet consectetur adipisicing elit. Sed accusantium placeat facere nesciunt sit veniam labore eligendi temporibus id, sunt earum, esse at laudantium explicabo dignissimos magnam! Maiores ducimus ea ipsa temporibus delectus, dicta modi, dolor pariatur perspiciatis accusantium accusamus id laborum. Illum, rem earum sint est obcaecati vitae possimus.</h3>
    
        </div>
      </div>
  );
};

export default DoctorDetailPage;
