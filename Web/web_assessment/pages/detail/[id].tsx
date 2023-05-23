import { useFetchUserByIdQuery } from "@/features/userSlice";
import Image from "next/image";
import { useRouter } from "next/router";

import background from "@/public/img/detailbg.png";

function DetailPage() {
  const router = useRouter();
  const { id } = router.query;

  const {
    data: doctor,
    isLoading,
    isError,
  } = useFetchUserByIdQuery(id as string);
  console.log(doctor);
  return (
    <div>
      <div className="flex flex-col p-5 gap-10">
        {doctor && (
          <>
            <div>
              <Image
                src={doctor.photo}
                alt={doctor.fullName}
                width={100}
                height={100}
                className="mx-auto rounded-full"
              />
            </div>
            <div className="flex">
              <section>
                <h1>{doctor.fullName}</h1>
                <p>{doctor.speciality[0].name}</p>
              </section>
              <section className="mx-auto">
                <span>{doctor.institutionID_list[0].institutionName}</span>
              </section>
            </div>
            <p>
              <span className="text-xl font-bold">About</span>
              <p>
                Lorem ipsum dolor, sit amet consectetur adipisicing elit. Dicta,
                nisi deleniti? Aspernatur aperiam adipisci, officia ipsum
                doloribus odit non, quis iste nobis quia praesentium, magnam
                repellat assumenda optio est dolorum. Lorem ipsum dolor, sit
                amet consectetur adipisicing elit. Dicta, nisi deleniti?
                Aspernatur aperiam adipisci, officia ipsum doloribus odit non,
                quis iste nobis quia praesentium, magnam repellat assumenda
                optio est dolorum.
              </p>
            </p>
            <div className="flex flex-col gap-4">
              <p>Education</p>
              <div className="flex justify-between">
                <section>
                  {doctor.institutionID_list[0].institutionName}
                </section>
                <section></section>
              </div>
              <p>Contact Info</p>
              <div className="flex justify-between">
                <section>
                  {doctor.institutionID_list[0].institutionName}
                </section>
                <section></section>
              </div>
            </div>
          </>
        )}
      </div>
    </div>
  );
}

export default DetailPage;
