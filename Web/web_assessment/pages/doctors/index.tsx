import { useEffect, useState } from "react";
import { useGetDoctorsDataMutation } from "../store/home/doctors-api";
import DoctorCard from "@/components/home/DoctorCard";

const HomePage = () => {
  const [doctorsData, setDoctorsData] = useState<DoctorData[]>([]);
  const [keyword, setKeyword] = useState("");
  const [getDoctorsData, { isLoading, isError }] = useGetDoctorsDataMutation();

  useEffect(() => {
    fetchData();
  }, [keyword]);

  const fetchData = async () => {
    try {
      const response = await getDoctorsData(keyword);
      if ("data" in response) {
        const doctorsData = response.data;

        setDoctorsData(doctorsData.data);
      } else {
      }
    } catch (error) {}
  };

  return (
    <section className="w-full">
      <form className="my-16 flex justify-center">
        <input
          className="rounded-full w-9/12 placeholder:text-xl border-gray-300 mx-auto outline-none border p-3 px-4"
          type="text"
          placeholder="Name"
          value={keyword}
          onChange={(e) => setKeyword(e.target.value)}
        />
      </form>
      {isLoading ? (
        <div className="text-center">Loading...</div>
      ) : isError ? (
        <div className="text-red-700">Error occurred while fetching data.</div>
      ) : (
        <div className="grid grid-cols-4 px-10 md:grid-cols-2 lg:grid-cols-4 gap-4">
          {doctorsData.map((doctorData) => {
            return <DoctorCard key={doctorData._id} doctorData={doctorData} />;
          })}
        </div>
      )}
    </section>
  );
};

export default HomePage;
