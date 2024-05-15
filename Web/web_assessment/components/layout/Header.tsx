import React from "react";
import Image from "next/image";

const Header = () => {
  return (
    <div className="bg-white flex justify-between px-20 pb-10">
      {/* logo */}
      <section className="flex gap-2">
        <Image
          src="/logo.png"
          className="object-contain"
          width={50}
          height={40}
          alt="logo"
        />
        <Image
          src="/HakimHub.png"
          className="object-contain"
          width={100}
          height={50}
          alt="hakim-hub"
        />
      </section>

      <section className="flex items-center gap-2">
        <Image
          className="object-contain"
          src="/img/user/avatar.png"
          width={70}
          height={70}
          alt="user-img"
        />
        <p>Jonathan Alemayehu</p>
      </section>
    </div>
  );
};

export default Header;
