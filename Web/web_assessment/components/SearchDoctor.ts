import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { searchDoctorById } from './searchSlice';
import DoctorCard from './DoctorCard';

const SearchDoctorPage = () => {
  const [doctorId, setDoctorId] = useState('');
  const dispatch = useDispatch();
  const doctor = useSelector((state) => state.search.doctor);

  const handleSearchSubmit = (event) => {
    event.preventDefault();
    dispatch(searchDoctorById(doctorId));
  };

  const handleDoctorIdChange = (event) => {
    setDoctorId(event.target.value);
  };

  return (
    <div>
      <form onSubmit={handleSearchSubmit}>
        <div>
          <label htmlFor="doctorId">Search for doctor by ID:</label>
          <input type="text" id="doctorId" value={doctorId} onChange={handleDoctorIdChange} />
        </div>
        <button type="submit">Search</button>
      </form>
      {doctor ? (
        <DoctorCard doctor={doctor} />
      ) : (
        <div>No doctor found.</div>
      )}
    </div>
  );
};

export default SearchDoctorPage;
