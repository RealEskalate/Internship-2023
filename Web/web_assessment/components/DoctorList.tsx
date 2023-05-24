import { DoctorDetail } from "@/types/doctor-detail";
import DoctorCard from "./DoctorCard";
import Link from "next/link";

interface DoctorListProps {
  doctordetails: DoctorDetail[];
}

const DoctorList: React.FC<DoctorListProps> = ({ doctordetails }) => {
  return (
    <div className="grid sm:grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-2 bg-white text-size mx-auto">
      {doctordetails?.map((detail: DoctorDetail) => (
        <Link href={`/details/${detail._id}`}>
          <DoctorCard doctorDetail={detail} />
        </Link>
      ))}
    </div>
  );
};

export default DoctorList;
