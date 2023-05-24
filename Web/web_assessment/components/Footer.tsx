// create a footer component wich have log of differnt social media and bg-blue

import React from "react";
import Image from 'next/image';


const Footer = () => {
  return (
    <div className="flex flex-col pr-10 bg-primary border-b-2 border-gray-100">
      <div className="flex items-center justify-between  p-4 bg-primary border-b-2 border-gray-100">
        <div className="flex justify-around items-center w-full">
          <h1 className="text-2xl font-semibold text-white">HakimHub</h1>
          <div className="flex gap-4">
            <div className="flex flex-col gap-1">
              <h1 className=" text-white font-semibold">Get Connected</h1>
              <p className=" text-white">&gt; For Physicians</p>
              <p className=" text-white">&gt; For Hospitals</p>
            </div>
            <div className="flex flex-col">
              <h1 className=" text-white font-semibold">Actions</h1>
              <p className=" text-white">&gt; For Physicians</p>
              <p className=" text-white">&gt; For Hospitals</p>
            </div>
            <div className="flex flex-col ">
              <h1 className=" text-white font-semibold"> Company</h1>
              <p className=" text-white">&gt; For Physicians</p>
              <p className=" text-white">&gt; For Hospitals</p>
            </div>
          </div>
        </div>
      </div>
      <hr className="w-full h-1 pl-10" />
      <div className="flex justify-between">
        <div className="flex gap-3">
            <p className=" text-white pl-10">Privacy Policy</p>
        <p className=" text-white pr-10">Terms of use</p>
        </div>
        <div className="flex gap-4">
        <Image
            className="object-cover h-full rounded-lg"
            src="/images/coolicon (1).png"
            alt="logo"
            width={40}
            height={40}
          /> 
          <Image
            className="object-cover h-full rounded-lg"
            src="/images/coolicon (2).png"
            alt="logo"
            width={40}
            height={40}
          /> 
          <Image
            className="object-cover h-full rounded-lg"
            src="/images/coolicon.png"
            alt="logo"
            width={40}
            height={40}
          /> 
        </div>
        
      </div>
    </div>
  );
};

export default Footer;
