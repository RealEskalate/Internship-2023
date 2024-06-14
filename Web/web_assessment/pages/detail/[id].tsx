"use client";
import { useParams } from "react-router-dom";
import { useGetDoctorDetailQuery } from "../../store/features/doctors/doctors-detail-api";
import { useRouter } from "next/router";
import Image from "next/image";
import NavigationBar from "@/components/layout/Navbar";
import Footer from "@/components/layout/Footer";

const DoctorDetailPage = () => {
  const router = useRouter();
  const { id } = router.query;
  console.log(id);
  const {
    data: doctor,
    isLoading,
    isError,
    error,
  } = useGetDoctorDetailQuery(id);
  console.log(doctor ?? "");

  if (isLoading) {
    return (
      <div className="min-h-screen bg-white font-{poppins} scroll-smooth self-center m-36 items-center">
        Loading...
      </div>
    );
  }

  if (isError) {
    return (
      <div className="min-h-screen bg-white font-{poppins} scroll-smooth self-center m-36 items-center">
        Error:
      </div>
    );
  }

  if (!doctor) {
    return (
      <div className="min-h-screen bg-white font-{poppins} scroll-smooth self-center m-36 items-center">
        No doctor found.
      </div>
    );
  }

  return (
    <div>
      {doctor && (
        <div className="min-h-screen bg-white font-{poppins} scroll-smooth self-center m-36 items-center">
        
          <div className="m-20 mt-11">
            <br />
            <div className="items-center self-center ml-96">
              <Image
                src={doctor.photo}
                alt={""}
                width={100}
                height={100}
                className={`rounded-full object-cover border-violet-800 border-2`}
              />
              <p>{doctor.institutionID_list[0].institutionName}</p>
            </div>
            <h1 className="font-semibold text-2xl">{doctor.fullName}</h1>
            <p>
              Lorem, ipsum dolor sit amet consectetur adipisicing elit.
              Veritatis voluptatibus neque tenetur est, placeat eaque eveniet
              sequi provident, sint quos officia tempora ex cum, dignissimos ab
              nam mollitia illo nulla dolor perspiciatis et sapiente laudantium
              aliquam. Beatae nulla cumque repudiandae dolores voluptatum neque
              rem tempora, dignissimos, eaque sed facere esse facilis voluptates
              consequatur atque optio dolorem quidem id, cum asperiores aliquam
              fugiat odio quam dicta! Fugiat eius doloribus dolores, perferendis
              aliquid voluptatum at earum velit. Dolor voluptate cum soluta
              natus recusandae placeat distinctio eum sequi nihil excepturi in
              pariatur maxime accusantium adipisci commodi eaque doloremque,
              nisi blanditiis, voluptas quia necessitatibus.
            </p>
          </div>
        </div>
      )}
    </div>
  );
};

export default DoctorDetailPage;
