import { useRouter } from "next/router";
import { useEffect } from "react";
import { useGetSingleDoctorQuery } from "../store/home/doctors-api";
import Image from "next/image";
import { MdEmail, MdPhone } from "react-icons/md";

const DetailPage = () => {
  const router = useRouter();
  const { DetailPage } = router.query;
  const id = DetailPage?.toString() || "";
  console.log(DetailPage, id);

  const { data, isLoading, isError, refetch } = useGetSingleDoctorQuery(id);
  console.log(data);

  useEffect(() => {
    if (id) {
      refetch();
    }
  }, [id, refetch]);

  return (
    <section className="w-full">
      {isLoading ? (
        <div className="text-center">Loading...</div>
      ) : isError ? (
        <div className="text-red-700">Error occurred while fetching data.</div>
      ) : (
        <div className="w-full sm:px-32 flex flex-col justify-center my-20">
          <div className="py-20 border rounded-xl">
            <h1 className="text-center py-10">Cover photo </h1>
          </div>{" "}
          <Image
            className="w-56 relative -my-24 content-center mx-auto rounded-full border-primary shadow-xl shadow-primary border-4"
            src={data?.photo}
            alt={data?.fullName}
            width={100}
            height={100}
          />
          <div className="flex sm:flex-row flex-col sm:space-x-56 my-36 mb-56">
            <div>
              <h2 className="text-4xl font-bold ">{data?.fullName}</h2>
              <h2 className="text-2xl py-1 text-secondary-text">
                {data?.speciality[0].name}
              </h2>
            </div>
            <div className="text-end text-secondary-text ">
              {/* I hard code it because there is no data.  */}
              <h3 className="text-lg">Addis Ababa University</h3>
              <h4 className="text-xl">
                {data.institutionID_list[0].institutionName}
              </h4>
            </div>
          </div>
          <div className="space-y-10 font-semibold ">
            <div className="flex sm:flex-row flex-col sm:space-x-56">
              <div>
                <h3 className="text-xl">Addis Ababa University</h3>
                <h3 className="text-lg text-secondary-text">B.SC medicine</h3>
              </div>
              <h3 className="text-xl text-secondary-text">2003 - 2007</h3>
            </div>
            <div className="flex sm:flex-row  flex-col sm:space-x-56">
              <div>
                <h3 className="text-xl">Addis Ababa University</h3>
                <h3 className="text-lg text-secondary-text">B.SC medicine</h3>
              </div>
              <h3 className="text-xl text-secondary-text">2003 - 2007</h3>
            </div>
          </div>
          <div>
            <h3 className="font-bold text-xl my-20">Contact Info</h3>
            <div className="flex space-x-4 mb-20">
              <MdPhone className="text-secondary-text mt-2" />
              <div>
                <p className="text-primary font-bold text-lg pb-2">Phone number</p>
                <p className="text-secondary-text">+25191111111</p>
              </div>
            </div>
            <div className="flex space-x-4">
              <MdEmail className="text-secondary-text mt-2" />
              <div>
                <p className="text-primary font-bold text-lg pb-2">Email</p>
                <p className="text-secondary-text">username@gmail.com</p>
              </div>
            </div>
          </div>
        </div>
      )}
    </section>
  );
};

export default DetailPage;
