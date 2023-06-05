import Hospital from "@/type/hospital/hospital";
import Image from "next/image";
import Link from "next/link";

interface HospitalProps {
    hospital: Hospital;
  }
const HospitalCard: React.FC<HospitalProps> = ({
    hospital
}) => {
 return (
    <Link href={`/hospital/${hospital._id}`}>
    <div className="flex flex-wrap rounded-lg bg-gray-200">
        <div className="w-1/3">
            <Image src={hospital.photo} alt={""} width={300} height={300}/>
        </div>
        <div className="flex flex-wrap w-2/3">
            <div className="w-1/2">
                <div>
                    {/* <div>{hospital.address.region}</div> */}
                    {/* <div>{hospital.institutionName}</div>
                    <div>{hospital.address.summary}</div> */}
                </div>
                <div  className="flex flex-wrap">
                    <div className="w-1/2">
                        <div>phone num1</div>
                        <div>phone num2</div>
                    </div>
                    <div className="w-1/2 justify-center">email</div>
                </div>
            </div>
            <div className="w-1/2 flex self-center justify-end">isopen now</div>
        </div>
    </div>
    </Link>
 )
};

export default HospitalCard;
