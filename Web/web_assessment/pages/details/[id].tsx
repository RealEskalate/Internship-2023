import { useFetchDoctorProfileQuery } from "@/store/hackimhub-api";
import Image from "next/image";
import { useRouter } from "next/router";
import coverImage from "@/public/img/cover-image.svg";
import { BsFillTelephoneFill } from "react-icons/bs";
import { MdEmail } from "react-icons/md";

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
      <div className="mx-auto">
        <Image src={coverImage} alt="" className="mx-auto" />
        <Image
          src={profile.photo}
          alt=""
          width={200}
          height={200}
          className="rounded-full mx-auto relative -top-20"
        />
        <div className="flex space-between ml-10">
          <div className="flex flex-col min-w-[500px] max-w-[700px]">
            <div className="font-bold">{profile.fullName}</div>
            <div>{profile.speciality[0].name}</div>
          </div>
          <div className="flex flex-col">
            {profile.institutionID_list.map((institution) => (
              <div>{institution.institutionName}</div>
            ))}
          </div>
        </div>
        <div className="max-w-[700px] mt-5 ml-10">
          <div className="font-bold">About</div>
          {profile.summary === "" ? "No summary" : profile.summary}
        </div>

        <div className="max-w-[700px] mt-10 ml-10">
          <div className="font-bold">Education</div>
          <div className="flex space-between w-full">
            {profile.education.length === 0 ? (
              "No education"
            ) : (
              <div className="flex flex-col">
                {profile.education.map((education) => (
                  <>
                    <p className="font-bold">{education.institutionName}</p>
                    <p>{education.degreeLevel}</p>
                  </>
                ))}
              </div>
            )}
          </div>
        </div>
        <div className="ml-10 mt-10">
          <div className="font-bold">Contact Info</div>
          <div className="flex flex-col">
            <div className="flex mt-3 ">
              <BsFillTelephoneFill className="mr-2 relative -bottom-1" />
              <span className="text-[#7879F1]">
                {!profile.phoneNumbers
                  ? "No phone number"
                  : profile.phoneNumbers[0]}
              </span>
            </div>
            <div className="flex mt-3">
              <MdEmail className="mr-2 relative -bottom-1" />
              <span className="text-[#7879F1]">
                {!profile.emails ? "No email" : profile.emails[0]}
              </span>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
};

export default ProfileDetail;
