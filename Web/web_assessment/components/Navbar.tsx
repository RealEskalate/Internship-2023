import Image from 'next/image';
import React from 'react';

const Navbar = () => {
  return (
    <>
    <div className="flex items-center justify-between w-full h-16 px-4 bg-white border-b-2 border-gray-100">
      <div className="flex items-center">
        <div className="flex items-center justify-center w-10 h-10 mr-2 rounded-full">
          <Image
            src="/images/frame.png"
            alt="logo"
            width={64}
            height={64}
          />
        </div>
        <h1 className="text-2xl font-semibold text-black">
          Hakim<span className="text-red-500">Hub</span>
        </h1>
      </div>
      <div className="flex items-center justify-center mr-2 rounded-full">
        <Image
          src="/images/Ellipse 26.png"
          alt="logo"
          width={54}
          height={54}
        />
        <h1 className="text-black">
          Jonathan Alemayehu<span className="text-sm h-2 m-1">v</span>
        </h1>
      </div>
      
    </div>
    <div className="flex items-center justify-center mr-2 rounded-full">
    <input
      className="w-full  px-24 h-10 text-sm text-gray-700 placeholder-gray-600 border rounded-full focus:outline-none focus:border-primary"
      type="text"
      placeholder="Search"
    />
  </div>
  </>
  );
};

export default Navbar;
