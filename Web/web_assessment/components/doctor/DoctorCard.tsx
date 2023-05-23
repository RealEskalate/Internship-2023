import { Doctor } from '@/types/doctor';
import Image from 'next/image';

interface DoctorCardProps {
  doctor: Doctor;
}

const DoctorCard: React.FC<DoctorCardProps> = ({ doctor }) => {
  const specialty = doctor.speciality[0]?.name || 'N/A';
  const region = doctor.institutionID_list[0]?.address?.region || 'N/A';
  const hospital = doctor.institutionID_list[0]?.institutionName || 'N/A';

  return (
    <div className="bg-white rounded-lg shadow-lg p-4">
      <div className="mb-4">
        <Image src={doctor.photo} alt={doctor.fullName} width={200} height={200} className="rounded-full" />
      </div>
      <h2 className="text-xl font-bold mb-2">{doctor.fullName}</h2>
      <p className="mb-2">Specialty: {specialty}</p>
      <p className="mb-2 flex items-center">
        <span>{region}</span>
        <span className="mx-2">|</span>
        <span>{hospital}</span>
      </p>
    </div>
  );
};

export default DoctorCard;
