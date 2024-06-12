import React from "react";

const NavBar: React.FC = () => {
  return (
    <nav className="flex items-center justify-between px-4 py-2 bg-gray-900 text-white">
      <div className="flex items-center space-x-4">
        <svg
          xmlns="http://www.w3.org/2000/svg"
          className="w-6 h-6 text-red-500 animate-pulse"
          fill="none"
          viewBox="0 0 24 24"
          stroke="currentColor"
        >
          <path
            strokeLinecap="round"
            strokeLinejoin="round"
            strokeWidth="2"
            d="M15 19l-7-7 7-7"
          />
        </svg>
        <span className="text-lg font-bold">HakimHub</span>
      </div>
      <div className="flex items-center space-x-2">
        <img
          className="w-8 h-8 rounded-full"
          src="https://via.placeholder.com/64"
          alt="Profile Image"
        />
        <span className="text-sm font-medium">John Doe</span>
      </div>
    </nav>
  );
};

export default NavBar;
