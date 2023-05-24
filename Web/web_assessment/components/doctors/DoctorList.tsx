import React, { useEffect, useState } from "react";
import { useGetDoctorsQuery } from "../../store/features/doctors/doctors-api";
import { DoctorData, Speciality } from "../../types/doctor";
import DoctorCard from "./DoctorCard";
import Footer from "../layout/Footer";
import NavigationBar from "../layout/Navbar";
import Pagination from "../common/pagination";

const DoctorList: React.FC = () => {
  const { data: doctors, isLoading, isError } = useGetDoctorsQuery({});

  const [currentPage, setCurrentPage] = useState(1);
  const [currentDoctors, setDoctors] = useState(doctors);

  const onPageChange = (page: number) => {
    setCurrentPage(page);
  };

  useEffect(() => {
    const start = (currentPage - 1) * 8;
    const end = start + 4;
    setDoctors(doctors?.data?.slice(start, end));
  }, [currentPage]);


  useEffect(() => {
    setDoctors(doctors);
  }, [doctors]);

  if (isLoading) {
    return <div>Loading...</div>;
  }

  if (isError) {
    return <div>Error occurred while fetching doctors.</div>;
  }

  const columns = 5; // Number of columns for doctors

  const chunkedDoctors = Array.from(
    { length: Math.ceil(doctors?.data?.length / columns) },
    (_, index) =>
      currentDoctors?.data?.slice(index * columns, (index + 1) * columns)
  );
  
  return (
    <div>
      <div className="doctor-grid">
        {chunkedDoctors?.map((doctorsPerColumn: DoctorData[], index) => (
          <div key={index} className="doctor-column">
            {doctorsPerColumn?.map((doctor: DoctorData) => (
              <div key={doctor._id}>
                <DoctorCard key={doctor._id} doctor={doctor} />
              </div>
            ))}
          </div>
        ))}
      </div>
      <div className="mt-16">
            <Pagination
              currentPage={currentPage}
              totalPages={Math.ceil(doctors.data.length / 8)}
              onPageChange={onPageChange}
            />
          </div>
    </div>
  );
};

export default DoctorList;
