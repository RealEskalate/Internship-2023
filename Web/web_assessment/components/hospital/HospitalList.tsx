import Image from "next/image";
import Link from "next/link";
import HospitalCard from "./HospitalCard";
import { usePostHospitalsQuery } from "@/ssttore/features/hospitals-api";
import { LoadingPage } from "../common/Loading";
import Hospital from "@/ttype/hospital/hospital";



const HospitalList: React.FC = () => {

  const { data: hospitals, isLoading, isError } = usePostHospitalsQuery("");

  if (isLoading) {
    return <LoadingPage />;
  }
  if (isError) {
    return <div className="min-h-screen">Error ... </div>;
  }
  return (
    <div className="p-44">
      {hospitals.data.map((hospital: Hospital) => (
        <div key={hospital._id} className="mb-8">
          <HospitalCard hospital = {hospital} />
        </div>
      ))}
    </div>
  );
};

export default HospitalList;
