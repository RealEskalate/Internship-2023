import Image from "next/image";
import { Doctor } from "@/types/doctor/doctor";
import Link from "next/link";

interface DoctorProps {
  doctor: Doctor;
}
const DoctorCard: React.FC<DoctorProps> = ({
  doctor: { photo, fullName, speciality, institutionID_list, _id },
}) => {
  return (
    <Link href={`/doctor/${_id}`}>
      <div className="bg-white mb-10 shadow-xl items-center  justify-center flex rounded-lg p-3">
        <div>
          <div className="justify-center flex">
            <Image
              src={photo}
              alt={""}
              width={150}
              height={150}
              className="rounded-full border-4 border-primary"
            />
          </div>

          <div className="font-bold justify-center flex">{fullName}</div>
          <div className="justify-center flex">
            <button className="rounded-full bg-primary m-3 pt-1 pb-1 pr-2 pl-2 text-text-primary">
              {speciality[0].name}
            </button>
          </div>
          <div className="justify-center flex">
            {institutionID_list[0].institutionName}
          </div>
        </div>
      </div>
    </Link>
  );
};

export default DoctorCard;
