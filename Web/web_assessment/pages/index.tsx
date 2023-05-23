import { useGetDoctorsQuery } from '@/store/doctor/doctors-api';
import DoctorCard from '@/components/doctor/DoctorCard';
import { Doctor } from "@/types/doctor";
import { Pagination } from "@/components/common/Pagination";
import { SearchForm } from "@/components/common/SearchForm";



const DoctorsList = () => {
  const { data: doctors, isLoading, isError } = useGetDoctorsQuery({ from: 1, size: 8 });
  console.log(doctors);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error occurred while fetching doctors.</div>;
  }

  if (!Array.isArray(doctors)) {
    return <div>No doctors found.</div>;
  }

  return (
    <div>
      <SearchForm />
      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
      {doctors.map((doctor: Doctor) => (
        <DoctorCard key={doctor._id} doctor={doctor} />
      ))}
    </div>
    <Pagination numberOfPages={5} />
    </div>
    
  );
};

export default DoctorsList;
