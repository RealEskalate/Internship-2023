import Image from "next/image";
import Link from "next/link";

interface Props {
  doctorData: DoctorData;
}

const DoctorCard: React.FC<Props> = ({ doctorData }) => {
  return (
    <Link href={`doctors/${doctorData._id}`}>
      <div className="bg-white rounded-3xl shadow-sm p-10 flex flex-col justify-center items-center">
        <Image
          className="w-30 rounded-full border-primary border-4"
          src={doctorData?.photo}
          alt={doctorData.fullName}
          width={100}
          height={100}
        />
        <h2 className="text-xl font-bold py-2">{doctorData.fullName}</h2>
        <div className="bg-primary rounded-full text-white px-3 my-4 font-semibold">
          {doctorData.speciality[0].name}
        </div>
        <p className="text-secondary-text">
          {doctorData.institutionID_list[0].institutionName}
        </p>
      </div>
    </Link>
  );
};

export default DoctorCard;
