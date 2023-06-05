import React from "react";
import Image from 'next/image';
import Link from 'next/link';


const Header = () => {
  return (
    <header className="flex justify-between items-center py-6 px-36">
      <div className="">
        <Image
          src="/img/logo.png"
          alt="logo"
          width={160}
          height={40}
          layout="fixed"
        />
      </div>
      <div className="flex items-center gap-2 mx-60">
        <ul className="flex space-x-4">
          <li>
            <Link href="/">
              <h1 className="font-bold">Home</h1>
            </Link>
          </li>
          <li>
            <Link href="/hospitals">
              <h1 className="font-bold">Hospitals</h1>
            </Link>
          </li>
          <li>
            <Link href="/doctors">
              <h1 className="font-bold">Doctors</h1>
            </Link>
          </li>
        </ul>
      </div>
      <div>
      <div className="flex">
        <div className="h-10 w-10 rounded-full border-2 bg-gray-600 mx-5">
          <p className="text-center my-1 text-white">K</p>
        </div>
        <button className="bg-white text-black py-2 px-4 rounded-full border border-gray-300 hover:bg-gray-200 focus:outline-none focus:bg-gray-200">
        Logout
      </button>
    </div>
    </div>
    </header>
  );
};

export default Header;
