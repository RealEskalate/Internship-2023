import HospitalCard from "./HospitalCard";
import { usePostHospitalsQuery } from "@/store/features/hospitals-api";
import { LoadingPage } from "../common/Loading";
import Hospital from "@/type/hospital/hospital";
import ErrorPage from "../common/Error";

interface SearchProps {
  searchValue: string;
}

const HospitalList: React.FC<SearchProps> = ({searchValue}) => {

  const { data: hospitals, isLoading, isError } = usePostHospitalsQuery(searchValue);

  if (isLoading) {
    return <LoadingPage />;
  }
  if (isError) {
    return <div className="min-h-screen">
      <ErrorPage />
    </div>;
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
