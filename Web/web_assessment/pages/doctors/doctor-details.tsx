import React from "react";
import { useRouter } from "next/router";
import DoctorDetails from "../../components/doctors/DoctorDetails";

const DoctorDetailsPage = () => {
  const router = useRouter();
  const { id } = router.query;

  if (!id) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <h1>Doctor Details Page</h1>
      <DoctorDetails />
    </div>
  );
};

export default DoctorDetailsPage;
