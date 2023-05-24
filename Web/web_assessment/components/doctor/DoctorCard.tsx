import { Doctor } from "@/types/doctor";
import Image from "next/image";
import Link from "next/link";

type DoctorCardProps = {
  doctor: Doctor;
};

const DoctorCard: React.FC<DoctorCardProps> = ({ doctor }) => {
  return (
    <Link href={`/profile/${doctor._id}`}>
      <div className="flex flex-col gap-y-3 pb-8 pt-4 w-72 items-center justify-center mx-auto bg-white rounded-xl shadow-md overflow-hidden">
        <div className="rounded-full border-4 border-primary">
          <Image src={doctor.photo} alt="Image" width={88} height={88} className="object-cover object-center rounded-full" />
        </div>
        <div>
          {doctor.fullName}
        </div>
        <div className="text-onPrimary text-xs font-extralight bg-primary rounded-full px-2 py-1">
          {doctor.speciality[0].name}
        </div>
        <div>
          {doctor.institutionID_list[0].institutionName}
        </div>
      </div>
    </Link>
  );
};

export default DoctorCard;
