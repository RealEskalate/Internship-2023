import { useGetDoctorProfileByIdQuery } from "@/store/features/api/doctors";
import { useEffect, useState } from "react";
import { useRouter } from "next/router";
import React from "react";
import Image from "next/image";
import { DoctorProfileResponse } from "@/types/doctor-profile";

const DoctorDetails = () => {
  const { id } = useRouter().query;
  const ID = id?.toString();
  const [profileData, setProfileData] = useState<DoctorProfileResponse>();

  const { data, isLoading, isError } = useGetDoctorProfileByIdQuery(ID!);

  useEffect(() => {
    setProfileData(data!);
  }, [data]);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError || profileData == undefined) {
    return <div>No Profile Data</div>;
  }

  console.log(profileData);
  const { photo, fullName, speciality, education, summary, emails } =
    profileData;
  return (
    <div className="bg-white">
      <section className="relative mb-40">
        <Image
          className="m-auto"
          src="/img/doctor-details/dummy-banner.png"
          alt="banner"
          width={1268}
          height={288}
        />
        <Image
          src={photo}
          alt="profile-pic"
          className="absolute top-3/4 left-1/2 right-1/2 inline object-cover self-center w-40 h-40 mr-2 rounded-full border-purple-600 "
          width={120}
          height={120}
        />
      </section>

      <section>
        <div>{fullName}</div>
        <div>{speciality[0]?.name}</div>
        <span>{education[0]}</span>
      </section>

      <section>
        <h1>About</h1>
        <p>{summary}</p>
      </section>

      {/* education */}
      <section></section>
      {/* contact info */}
      <section></section>
    </div>
  );
};

export default DoctorDetails;
