import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../store";
import { fetchDoctors } from "../../store/doctor-slices";
import { Doctor } from "@/types/doctor";

const DoctorList: React.FC = () => {
  const dispatch = useDispatch();
  const { list, loading, error } = useSelector(
    (state: RootState) => state.doctors
  );

  useEffect(() => {
    dispatch(fetchDoctors());
  }, [dispatch]);

  if (loading) {
    return <div>Loading...</div>;
  }

  if (error) {
    return <div>Error: {error}</div>;
  }

  return (
    <div>
      <h2>Doctor List</h2>
      {list.map((doctor: Doctor) => (
        <div key={doctor.id}>
          <h3>{doctor.fullName}</h3>
          <p>Specialty: {doctor.speciality}</p>
        </div>
      ))}
    </div>
  );
};

export default DoctorList;
