import { Doctor } from "../../types/doctor/doctor";
import { LoadingPage } from "../common/Loading";
import DoctorCard from "./DoctorCard";
import { usePostDoctorsQuery } from "@/store/features/doctor/doctors-api";
const DoctorList: React.FC = () => {
  const { data: doctors, isLoading, isError } = usePostDoctorsQuery("");

  if (isLoading) {
    return <LoadingPage />;
  }
  if (isError) {
    return <div className="min-h-screen">Error ... </div>;
  }
  return (
    <div>
      <div className="bg-white">
        <input
          type="text"
          placeholder="Search"
          className="rounded-full w-2/3 h-10 mt-10 ml-40 pl-[20px] border-2"
        />
      </div>
      <div className="min-h-screen bg-white grid grid-cols-4 gap-4 p-16">
        {doctors.data.map((doctor: Doctor) => (
          <DoctorCard doctor={doctor} />
        ))}
      </div>
    </div>
  );
};

export default DoctorList;
