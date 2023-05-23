import DoctorList from "@/components/DoctorList";
import { useFetchDoctorsQuery } from "@/store/hackimhub-api";
import { useState } from "react";

export default function Home() {
  const [keyword, setKeyword] = useState("");
  const { data: currentData = { data: [] } } = useFetchDoctorsQuery(keyword);

  const handleChange = (event: any) => setKeyword(event.target.value);

  return (
    <div>
      <div className="relative w-[90%] mx-auto my-4 rounded-lg">
        <input
          type="search"
          onChange={handleChange}
          value={keyword}
          className="block w-full p-4 pl-10 text-sm text-gray-900 border border-gray-300 rounded-lg bg-gray-50 focus:ring-blue-500 focus:border-blue-500 dark:bg-gray-700 dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500"
          placeholder="Name, speciality"
        />
      </div>
      <DoctorList doctordetails={currentData.data} />
    </div>
  );
}
