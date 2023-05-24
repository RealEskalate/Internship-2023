import DoctorDetail from '@/components/doctor/DoctorDetail';
import Footer from '@/components/layout/Footer';
import Navbar from '@/components/layout/Navbar';
import { useGetDoctorByIdQuery } from '@/store/doctor/doctors-api';
import { useRouter } from 'next/router';

const DoctorDetailPage = () => {
  const router = useRouter();
  const blogID = router.query.id as string;

  const { data: doctor, isSuccess, isLoading, isError, error } = useGetDoctorByIdQuery(blogID);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>{error.toString()}</div>;
  }

  if (isSuccess) {
    return (
      <div>
        <Navbar />
      <div className="bg-white text-black flex items-center justify-center h-screen">
        {/* Render the DoctorDetail component with a key */}
        <DoctorDetail key={doctor._id} doctor={doctor} />
      </div>
      <Footer />
      </div>
    );
  }
};

export default DoctorDetailPage;
