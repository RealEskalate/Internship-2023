import React from "react";

const NavBar = () => {
  // Random profile image URL
  const profileImage = "https://randomuser.me/api/portraits/men/1.jpg";

  // Random name
  const randomName = "John Doe";

  return (
    <nav className="flex items-center justify-between bg-gray-100 text-gray-900 p-4 shadow-md z-10 mb-6">
      <div className="flex items-center">
        <img
          src="/hakimhub-logo.png" // Replace with the actual path to your logo image
          alt="hakimhub Logo"
          className="w-12 h-12 mr-2"
        />
        <h1 className="text-2xl font-bold">hakimhub</h1>
      </div>

      <div className="flex items-center">
        <img
          src={profileImage}
          alt="Profile"
          className="w-10 h-10 rounded-full mr-2"
        />
        <p>{randomName}</p>
      </div>
    </nav>
  );
};

export default NavBar;
