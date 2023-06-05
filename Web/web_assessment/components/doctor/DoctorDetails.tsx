import Image from "next/image";
import { useGetDoctorDetailQuery } from "../../store/features/doctor/doctor-detail-api";
import { useRouter } from "next/router";
import Link from "next/link";
import { LoadingPage } from "../common/Loading";

export const DoctorDetails: React.FC = () => {
  const router = useRouter();
  const { id } = router.query;

  const { data: doctor, isLoading, isError } = useGetDoctorDetailQuery(id);

  if (isLoading) {
    return <LoadingPage />;
  }
  if (isError) {
    return <div>Error....</div>;
  }
  return (
    <div className="">
      <div className="">
        <div className="p-10 flex justify-center ">
          <Image
            src="/image/background.png"
            alt={""}
            width={1400}
            height={350}
            className="rounded-lg"
          />
        </div>

        <div className="-mt-36 flex justify-center">
          <Image
            src={doctor.photo}
            alt={""}
            width={150}
            height={150}
            className="rounded-full border-primary border-4"
          />
        </div>
      </div>
      <div className="pl-36 pr-36 pt-2 pb-8 ">
        <div className="flex flex-wrap pb-4">
          <div className="w-1/2">
            <div className="text-3xl font-bold">{doctor.fullName}</div>
            <div>{doctor.speciality[0].name}</div>
          </div>
          <div className="w-1/2">
            <div>Addis Ababa University</div>
            <div>Medical Dr</div>
          </div>
        </div>
        <div>
          <div className="font-extrabold text-md">About</div>
          <div>{doctor.institutionID_list[0].lang.am.summary}</div>
        </div>
        <div>
          <div className="font-extrabold text-lg pt-10 pb-8">Education</div>
          <div>
            <div className="flex flex-wrap pb-12">
              <div className="w-1/2">
                <div className="font-bold text-xl">Addis Ababa University</div>
                <div className="text-lg">Bsc Medicine</div>
              </div>
              <div className="self-center w-1/2 font-light text-xl text-gray-500">2003 - 2007</div>
            </div>
            <div className="flex flex-wrap">
              <div className="w-1/2">
                <div className="font-bold text-lg">Addis Ababa University</div>
                <div className="text-lg">Bsc Medicine</div>
              </div>
              <div className="self-center w-1/2 font-light text-xl text-gray-500">2007 - 2015</div>
            </div>
          </div>
        </div>
        <div>
          <div></div>
          <div></div>
        </div>
      </div>
    </div>
  );
};
