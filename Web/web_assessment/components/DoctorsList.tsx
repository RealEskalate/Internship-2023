import { useGetDoctorsQuery } from './../store/doctor/doctorapi';
import DoctorCard from './DoctorsCard';
import {Doctor} from './../types/doctor'
import { Link } from 'react-router-dom';

const DoctorsPage = () => {
const { data: doctors, isLoading, isError } = useGetDoctorsQuery();
if (isError) {
  return <div>Error: {isError.toString()}</div>;
}

if (doctors === undefined || isLoading) {
  return <div>Loading...</div>;
}

  return (
    <div className='display-flex flex-row mx-10 my-10' >
      {doctors.map((doctor : Doctor) => (
      <Link key={doctor.id} to={`/doctors/${doctor.id}`}>
      <DoctorCard key={doctor.id} doctor={doctor} /></Link>
      ))}
    </div>
  );
};

export default DoctorsPage;
