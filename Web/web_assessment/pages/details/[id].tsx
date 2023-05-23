import { useFetchDoctorProfileQuery } from "@/store/hackimhub-api";
import Image from "next/image";
import { useRouter } from "next/router";

import { useEffect } from "react";

const ProfileDetail: React.FC = () => {
  const router = useRouter();
  let { id } = router.query;
  id = id as string;

  const { data: profile, isLoading } = useFetchDoctorProfileQuery(id);

  useEffect(() => {
    console.log(profile);
  }, [profile]);

  if (isLoading) {
    return <div> loading ... </div>;
  }
  if (!profile) {
    return <div>Profile not found</div>;
  }

  return (
    <div className="m-auto">
      <div className="w-[85%] mx-auto">
        <div className="relative flex flex-col min-w-0 break-words bg-white w-full mb-6 shadow-xl rounded-lg mt-16">
          <div className="px-6">
            <div className="flex flex-wrap justify-center">
              <div className="w-full px-4 flex justify-center">
                <div className="relative">
                  <Image
                    alt="..."
                    width={10}
                    height={10}
                    src={profile.photo}
                    className="shadow-xl rounded-full h-auto align-middle border-none absolute -m-16 -ml-20 lg:-ml-16 max-w-150-px"
                  />
                </div>
              </div>
            </div>
            <div className="text-center mt-12">
              <h3 className="text-xl font-semibold leading-normal mb-2 text-blueGray-700 mb-2">
                {profile.fullName}
              </h3>
              <div className="text-sm leading-normal mt-0 mb-2 text-blueGray-400 font-bold uppercase">
                <i className="fas fa-map-marker-alt mr-2 text-lg text-blueGray-400"></i>
                {profile?.speciality[0].name}
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProfileDetail;
