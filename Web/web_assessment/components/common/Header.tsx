import React from "react";
import Image from 'next/image'

const Header: React.FC = () => {
  return (
    <header className="flex justify-between">
      <Image
        src="/img/logo.png"
        alt="logo"
        width={160}
        height={8}
        className="mt-8 ml-36"
      />
    </header>
  );
};

export default Header;
