import React, { useEffect } from "react";
import { useDispatch, useSelector } from "react-redux";
import { RootState } from "../../store";
import { fetchDoctors } from "../../store/doctor-slices";

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
      {list.map((doctor) => (
        <div key={doctor.id}>
          <h3>{doctor.name}</h3>
          <p>Specialty: {doctor.specialty}</p>
        </div>
      ))}
    </div>
  );
};

export default DoctorList;
