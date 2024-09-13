import React from "react";
import Image from "next/image"

const Navbar: React.FC = () => {
  return (
    <nav className="flex items-center justify-between flex-wrap bg-gray-800 p-6">
      <div className="flex items-center flex-shrink-0 mr-6">
        <Image  src = "/profile/frame.png" alt = {"logo"} width = {59} height = {59}/>
        <Image  src = "/profile/hakim-hub.png" alt = {"logo"} width = {181} height = {47}/>  
      </div>
      <div className="flex items-center">
        <div className="font-semibold text-sm mr-4"><h1>Brook Worku</h1></div>
      </div>
    </nav>
  );
};

export default Navbar;