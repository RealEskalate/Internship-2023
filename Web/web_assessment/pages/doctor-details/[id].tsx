import { useGetDoctorProfileByIdQuery } from "@/store/features/api/doctors";
import { useEffect, useState } from "react";
import { useRouter } from "next/router";
import React from "react";
import Image from "next/image";
import { DoctorProfileResponse } from "@/types/doctor-profile";
import { MdCall } from "react-icons/md";

const DoctorDetails = () => {
  const { id } = useRouter().query;
  const ID = id?.toString();
  const [profileData, setProfileData] = useState<DoctorProfileResponse>();

  const { data, isLoading, isError } = useGetDoctorProfileByIdQuery(ID!);

  useEffect(() => {
    setProfileData(data!);
  }, [data]);

  if (isError || profileData == undefined) {
    return <div>No Profile Data</div>;
  }

  console.log(profileData);
  const { photo, fullName, speciality, education, summary, emails } =
    profileData;

  return (
    <div className="bg-white ">
      {isLoading ? (
        <div>Loading...</div>
      ) : (
        <div className="mx-40">
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
              className="absolute top-3/4 left-1/2 right-1/2 inline object-cover self-center w-40 h-40 mr-2 rounded-full border-4 border-purple-600 "
              width={120}
              height={120}
            />
          </section>

          <section className="w-1/2">
            <section>
              <div className="text-5xl">{fullName}</div>
              <div className="text-2xl">{speciality[0]?.name}</div>
              <span>{education[0]}</span>
            </section>

            <section className="my-16">
              <h1 className="text-lg font-bold">About</h1>
              <p>{summary}</p>
              {summary === "" && (
                <p>
                  Lorem ipsum dolor sit amet, consectetur adipiscing elit. Duis
                  pellentesque purus sit amet mi aliquam, id dictum augue
                  vulputate. Pellentesque porta, ligula non pulvinar
                  sollicitudin, dolor nunc molestie dui, sit amet volutpat eros
                  nibh vitae magna. Nullam tempor, purus nec rutrum varius, arcu
                  massa scelerisque diam, nec vestibulum diam neque a massa.
                  Mauris tempor odio in ornare cursus. Maecenas in ultricies
                  sapien. Suspendisse dolor turpis, pretium vitae lacus eget,
                  condimentum aliquam diam.
                </p>
              )}
            </section>

            {/* education */}
            <section>
              <h1 className="text-lg font-bold">Education</h1>
              {Array(2)
                .fill(0)
                .map((_, index) => (
                  <div className="flex justify-between mb-10" key={index}>
                    <div className="flex flex-col gap-y-1">
                      <h1 className="text-xl font-bold">
                        Addis Ababa University
                      </h1>
                      <span className="text-base">B. Sc Medicine</span>
                    </div>
                    <p className="font-light text-2xl">2003 - 2007</p>
                  </div>
                ))}
            </section>

            {/* contact info */}
            <section className="mb-12">
              <h1 className="text-lg font-bold mb-12">Contact Info</h1>
              <div>
                <MdCall className="inline mx-5" />
                <h1 className="inline text-lg text-purple-700">
                  Phone Number:
                </h1>
              </div>
              <p className="ml-10">+25111763498</p>
            </section>

            <section className="pb-12">
              <div>
                <MdCall className="inline mx-5" />
                <h1 className="inline text-lg text-purple-700">Email:</h1>
              </div>
              <p className="ml-10">fasiltefera@stpaul.com</p>
            </section>
          </section>
        </div>
      )}
    </div>
  );
};

export default DoctorDetails;
