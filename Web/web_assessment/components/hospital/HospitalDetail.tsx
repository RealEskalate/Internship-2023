import React from "react";

const HospitalDetail = () => {
  return (
    <div className="flex flex-col items-center">
      <img
        src="./logo"
        alt="Hospital Image"
        className="w-full h-auto"
      />
      <h1 className="text-4xl font-bold mt-4">Black Lion Hospital</h1>
      <div className="flex flex-wrap justify-center items-center mt-2">
        <div className="p-2 bg-green-500 text-white mb-2 sm:mb-0 sm:mr-2">
          Open Now
        </div>
        <div className="p-2 bg-blue-200 sm:ml-2">Open 24 Hours</div>
      </div>
      <p className="my-4">
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed auctor urna
        vitae sem rutrum, a ullamcorper nisl tincidunt.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed auctor urna
        vitae sem rutrum, a ullamcorper nisl tincidunt.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed auctor urna
        vitae sem rutrum, a ullamcorper nisl tincidunt.Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed auctor urna
        vitae sem rutrum, a ullamcorper nisl tincidunt.
      </p>
      <h2 className="text-2xl font-bold">Services</h2>
      <ul className="flex flex-wrap my-4">
        <li className="mr-4 mb-2">Service 1</li>
        <li className="mr-4 mb-2">Service 2</li>
        <li className="mr-4 mb-2">Service 3</li>
        <li className="mr-4 mb-2">Service 4</li>
      </ul>
      <div className="flex flex-wrap justify-center bg-gray-200 p-4">
        <div className="w-full sm:w-auto sm:mr-4 mb-4 sm:mb-0">
          <h3 className="font-bold">Main Office</h3>
          <p>Location 1</p>
        </div>
        <div className="w-full sm:w-auto sm:mr-4 mb-4 sm:mb-0">
          <h3 className="font-bold">Laboratory Office</h3>
          <p>Location 2</p>
        </div>
        <div className="w-full sm:w-auto">
          <p>Email</p>
          <p>Location</p>
        </div>
      </div>
    </div>
  );
};

export default HospitalDetail;
