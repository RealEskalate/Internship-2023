import React, { useState } from "react";
import Image from "next/image";
import { Inter } from "next/font/google";
import HospitalList from "@/components/hospital/HospitalList";

const inter = Inter({ subsets: ["latin"] });

export default function Home() {
  const [searchValue, setSearchValue] = useState("");

  const handleSearchChange = (event) => {
    setSearchValue(event.target.value);
  };

  return (
    <div className="min-h-screen bg-white">
      <div className="bg-white">
        <input
          type="text"
          placeholder="Search"
          value={searchValue}
          onChange={handleSearchChange}
          className="w-2/3 h-10 mt-10 ml-40 pl-[20px] border-2"
        />
      </div>
      <div>
        <HospitalList searchValue={searchValue} />
      </div>
    </div>
  );
}
