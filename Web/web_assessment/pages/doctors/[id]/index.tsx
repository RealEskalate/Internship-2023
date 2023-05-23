import Error from "@/components/common/Error";
import { useGetDoctorQuery } from "@/store/features/doctors/doctors-api";
import Image from "next/image";
import { useParams } from "next/navigation";
import { useRouter } from "next/router";
import React from "react";

const DoctorProfile: React.FC = () => {
  const router = useRouter();
  const { id } = router.query;
  let {
    data: doctor,
    isLoading,
    isSuccess,
    isError,
    error,
  } = useGetDoctorQuery(id);

  let content;

  if (isLoading) {
    content = (
      <div>
        <div className="animate-pulse flex flex-col self-start bg-white rounded-lg p-6 m-2 items-center justify-center shadow-xl w-[400px]">
          <div className="rounded-full w-32 h-32 mt-2 bg-gray-200 object-contain"></div>
          <div className="w-1/2 h-5 bg-gray-200 m-3"></div>
          <div className="w-1/3 h-5 bg-gray-200"></div>
          <div className="flex flex-col my-4 p-4 w-full gap-3">
            <div className="w-full h-5 bg-gray-200"></div>
            <div className="w-full h-5 bg-gray-200"></div>
            <div className="w-full h-5 bg-gray-200"></div>
            <div className="w-full h-5 bg-gray-200"></div>
          </div>
        </div>
      </div>
    );
  } else if (isSuccess) {
    if (!doctor) content = <Error error={"Not Found"}></Error>;
    else
      content = (
        <div>
          <Image
            className="rounded-full border-2 border-primary mx-auto"
            unoptimized
            src={doctor.photo}
            alt="doctor phot"
            width={227}
            height={227}
          ></Image>
          <div className="max-w-lg p-4 my-10 flex flex-col gap-8">
            <div className="flex justify-between items-center">
              <div className="flex flex-col">
                <p className="font-bold text-xl">{doctor?.fullName} </p>
                <p>Internal Medicine</p>
              </div>

              <div className="flex flex-col">
                <p className="text-sm">Addis Ababa University </p>
                <p></p>
              </div>
            </div>

            <div className="flex justify-between items-center">
              <div className="flex flex-col">
                <p className="font-bold text-xl">About </p>
                <p>{doctor?.summary}</p>
              </div>
            </div>
          </div>
        </div>
      );
  } else if (isError) {
    content = <Error error={"error fetching data"}></Error>;
  }

  return <div className="">{content}</div>;
};

export default DoctorProfile;
