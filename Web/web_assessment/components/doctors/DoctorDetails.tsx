import { useRouter } from "next/router";
import { useGetDoctorProfileQuery } from "../../store/features/doctors/doctor-api";

const DoctorDetails = () => {
  const router = useRouter();
  const { id } = router.query;
  if (!id) {
    return <div>Loading...</div>;
  }

  const {
    data: doctor = {},
    isLoading,
    isError,
  } = useGetDoctorProfileQuery(id as string);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error while fetching doctor details.</div>;
  }

  return (
    <div>
      <h1>Doctor Details</h1>
      <div>
        <h2>{doctor.name}</h2>
        <p>{doctor.specialty}</p>
      </div>
    </div>
  );
};

export default DoctorDetails;
