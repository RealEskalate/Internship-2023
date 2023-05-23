import { useParams } from 'react-router-dom';
import { useGetDoctorDetailQuery } from '../store/features/doctors/doctors-detail-api'

const DoctorDetailPage = () => {
    // const { id } = useParams();
    // console.log(id)
    const { data: doctor, isLoading, isError, error } = useGetDoctorDetailQuery({});
   
    if (isLoading) {
      return <div>Loading...</div>;
    }
  
    if (isError) {
      return <div>Error: </div>;
    }
  
    if (!doctor) {
      return <div>No doctor found.</div>;
    }
  
    return (
      <div>
        <h2>Doctor Detail</h2>
        <p>ID: {doctor._id}</p>
        <p>Name: {doctor.fullName}</p>
        {/* <p>Specialty: {doctor.specialty}</p> */}
        {/* Render more doctor details */}
      </div>
    );
  };

  export default DoctorDetailPage