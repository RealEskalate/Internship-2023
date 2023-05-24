import React from "react";

const Footer: React.FC = () => {
  return (
    <footer className="bg-indigo-500 text-white py-4 px-8">
      <div className="flex justify-between items-center">
        <div className="text-white">
          <span className="font-bold">HakimHub</span>
        </div>
        <div className="flex space-x-4">
          <a href="#" className="text-white">
            Get Connected
          </a>
          <a href="#" className="text-white">
            For Physicians
          </a>
          <a href="#" className="text-white">
            For Patients
          </a>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
