import DoctorCard from "@/components/doctors/DoctorCard";
import {
  useGetDoctorsMutation,
  useSearchMutation,
} from "@/store/features/api/doctors";
import { Doctor } from "@/types/doctors";
import Link from "next/link";
import React, { useEffect, useState } from "react";

const DoctorsList = () => {
  const [getDoctors, { isLoading, isError, error }] = useGetDoctorsMutation();
  const [doctors, setDoctors] = useState<Doctor[]>([]);
  const [inputValue, setValue] = useState("");
  const [search, { isLoading: rand, isError: rand2, error: rand3 }] =
    useSearchMutation(inputValue);

  const handleGetDoctors = async () => {
    try {
      const response = await getDoctors();
      setDoctors(response.data.data);
    } catch (error) {
      console.log(error);
    }
  };

  const handleSearch = async (e: React.FormEvent) => {
    e.preventDefault();
    setValue((e.target as HTMLInputElement).value);
    try {
      const response = await search(inputValue);
      setDoctors(response.data.data);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    handleGetDoctors();
  }, []);

  if (isLoading) {
    return <div>Loading doctors...</div>;
  }

  if (isError) {
    return <div>No doctors</div>;
  }

  return (
    <>
      {isLoading ? (
        <div>Loading </div>
      ) : (
        <div>
          <div className="flex items-center">
            <div className="flex space-x-1">
              <form onSubmit={handleSearch}>
                <input
                  type="text"
                  value={inputValue}
                  className="block w-full px-4 py-2 text-purple-700 bg-white border rounded-full focus:border-purple-400 focus:ring-purple-300 focus:outline-none focus:ring focus:ring-opacity-40"
                  placeholder="Search..."
                  onChange={handleSearch}
                />
              </form>
            </div>
          </div>
          <div className="flex flex-wrap gap-16">
            {doctors.map((doctor) => (
              <Link
                key={doctor._id}
                href={`doctor-details/${doctor._id}`}
                target="_blank"
              >
                <DoctorCard {...doctor} />
              </Link>
            ))}
          </div>
        </div>
      )}
    </>
  );
};

export default DoctorsList;
