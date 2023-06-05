import Search from '@/components/common/Search';
import HospitalDetail from '@/components/hospital/HospitalDetail';
import { useGetHospitalsQuery } from '@/store/hospital/hospital-api';
import Navbar from '@/components/layout/Navbar';
import { Welcome, Datum } from '@/types/Hospital';
import HospitalCard from '../components/hospital/HospitalCard';
import Footer from '@/components/layout/Footer';

const HospitalsList = () => {
  const { data: hospitals, isLoading, isError } = useGetHospitalsQuery();

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error occurred while fetching hospitals.</div>;
  }

  if (!Array.isArray(hospitals?.data)) {
    return <div>No hospitals found.</div>;
  }

  return (
    <div>
      <Navbar />
      {/* <Search/> */}
      <div className="grid gap-4 md:grid-cols-2 lg:grid-cols-3 xl:grid-cols-4">
        {hospitals?.data.map((hospital: Datum) => (
          <HospitalCard key={hospital._id} hospital={hospital} />
        ))}
      </div>
      <Footer />
    </div>
  );
};

export default HospitalsList;
