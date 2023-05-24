import React from "react";
import Image from 'next/image'
import { FaAngleDown } from 'react-icons/fa';

const Header: React.FC = () => {
  return (
    <header className="flex justify-between items-center py-6 px-36">
      <Image
        src="/img/logo.png"
        alt="logo"
        width={160}
        height={8}
      />
      <div className="flex items-center gap-2">
        <div className="h-10 w-10 rounded-full border-2 border-primary">
          <Image src="https://picsum.photos/200" alt="image" width={38} height={38} className="object-cover object-center rounded-full" />
        </div>
        <div className="text-sm">Jonathan Alemayehu</div>
        <FaAngleDown />
      </div>
    </header>
  );
};

export default Header;
