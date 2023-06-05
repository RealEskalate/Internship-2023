import Hospital from "@/type/hospital/hospital";
import Image from "next/image";
import Link from "next/link";
import { IsOpen } from "../common/IsOpen";
interface HospitalProps {
  hospital: Hospital;
}


const HospitalCard: React.FC<HospitalProps> = ({ hospital }) => {
  console.log(hospital);
  return (
    <Link href={`/hospital/${hospital._id}`}>
      <div className="flex flex-wrap rounded-lg bg-gray-200">
        <div className="w-1/3 ">
          <Image
            src={hospital.photo}
            alt={""}
            width={300}
            height={300}
            className="rounded-lg "
          />
        </div>
        <div className="flex flex-wrap w-2/3  self-center pt-4 pb-4">
          <div className="w-2/3">
            <div className="mb-10">
              <div>{hospital.address.region}</div>
              <div className="font-extrabold pt-2 pb-2 text-xl">
                {hospital.institutionName}
              </div>
              <div>{hospital.address.summary}</div>
            </div>
            <div className="flex flex-wrap">
              <div className="w-1/2">
                {hospital?.phoneNumbers?.map((phone: string) => (
                  <div key={hospital._id} className="mb-3">
                    {phone}
                  </div>
                ))}
              </div>
              <div className="w-1/2 justify-center">
              {hospital?.emails?.map((email: string) => (
                  <div key={hospital._id} className="mb-3">
                    {email}
                  </div>
                ))}
              </div>
            </div>
          </div>
          <div className="w-1/3 flex self-center justify-end pr-10">
            <IsOpen isopen={hospital.status} />
          </div>
        </div>
      </div>
    </Link>
  );
};

export default HospitalCard;
