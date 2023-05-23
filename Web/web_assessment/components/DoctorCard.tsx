import { DoctorDetail } from "@/types/doctor-detail";
import Image from "next/image";

interface DoctorCardProps {
  doctorDetail: DoctorDetail;
}

const DoctorCard: React.FC<DoctorCardProps> = ({ doctorDetail }) => {
  return (
    <div className="w-full max-w-sm bg-white border border-gray-200 rounded-lg dark:bg-gray-800 dark:border-gray-700">
      <div className="flex justify-end px-4 pt-4">
        <div
          id="dropdown"
          className="z-10 hidden text-base list-none bg-white divide-y divide-gray-100 rounded-lg shadow w-44 dark:bg-gray-700"
        >
          <ul className="py-2" aria-labelledby="dropdownButton">
            <li>
              <a
                href="#"
                className="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 dark:hover:bg-gray-600 dark:text-gray-200 dark:hover:text-white"
              >
                Edit
              </a>
            </li>
            <li>
              <a
                href="#"
                className="block px-4 py-2 text-sm text-gray-700 hover:bg-gray-100 dark:hover:bg-gray-600 dark:text-gray-200 dark:hover:text-white"
              >
                Export Data
              </a>
            </li>
            <li>
              <a
                href="#"
                className="block px-4 py-2 text-sm text-red-600 hover:bg-gray-100 dark:hover:bg-gray-600 dark:text-gray-200 dark:hover:text-white"
              >
                Delete
              </a>
            </li>
          </ul>
        </div>
      </div>
      <div className="flex flex-col items-center pb-10">
        <Image
          src={doctorDetail.photo}
          alt={doctorDetail.fullName}
          width={10}
          height={10}
          className="w-24 h-24 mb-3 rounded-full shadow-lg"
        />
        <h5 className="mb-1 text-xl font-medium text-gray-900 dark:text-white">
          {doctorDetail.fullName}
        </h5>
        <span className="text-sm text-gray-500 dark:text-gray-400">
          {doctorDetail.speciality[0].name}
        </span>
        <div className="flex mt-4 space-x-3 md:mt-6">
          {doctorDetail.institutionID_list[0].institutionName}
        </div>
      </div>
    </div>
  );
};

export default DoctorCard;
