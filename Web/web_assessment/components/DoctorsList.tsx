import React, { useState } from 'react';
import { useGetDoctorsQuery } from './../store/doctor/doctorapi';
import DoctorCard from './DoctorsCard';
import { Doctor } from './../types/doctor';
import { Link } from 'react-router-dom';

const DoctorsPage = () => {
  const [currentPage, setCurrentPage] = useState(1);
  const [perPage] = useState(10); 
  const { data: doctors, isLoading, isError } = useGetDoctorsQuery();

  const indexOfLastDoctor = currentPage * perPage;
  const indexOfFirstDoctor = indexOfLastDoctor - perPage;
  const currentDoctors = doctors?.slice(indexOfFirstDoctor, indexOfLastDoctor) || [];

 
  const handlePageChange = (pageNumber) => {
    setCurrentPage(pageNumber);
  };

  if (isError) {
    return <div>Error: {isError.toString()}</div>;
  }

  if (!doctors || isLoading) {
    return <div>Loading...</div>;
  }

  return (
    <div>
      <div className='display-flex flex-row mx-10 my-10'>
        {currentDoctors.map((doctor: Doctor) => (
          <Link key={doctor.id} to={`/doctors/${doctor.id}`}>
            <DoctorCard key={doctor.id} doctor={doctor} />
          </Link>
        ))}
      </div>
      <div className="pagination-container">
        {Array.from({ length: Math.ceil(doctors.length / perPage) }).map((_, index) => (
          <button
            key={index + 1}
            onClick={() => handlePageChange(index + 1)}
            className={`pagination-button ${currentPage === index + 1 ? 'active' : ''}`}
          >
            {index + 1}
          </button>
        ))}
      </div>
    </div>
  );
};

export default DoctorsPage;
