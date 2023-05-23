import React from "react";
import DoctorsList from "../../components/doctors/DoctorsList";

const DoctorsListPage = () => {
  return (
    <div>
      <div className="mb-4">
        <input
          type="text"
          placeholder="Search "
          className="w-full px-4 py-2 border rounded focus:outline-none"
        />
      </div>
      <DoctorsList />
    </div>
  );
};

export default DoctorsListPage;
