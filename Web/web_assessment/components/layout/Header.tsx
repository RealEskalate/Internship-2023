import React from "react";
import Image from "next/image";

const Header = () => {
  return (
    <div className="bg-white flex justify-between">
      {/* logo */}
      <section className="flex">
        <Image
          src="/logo.png"
          className="object-cover"
          width={90}
          height={90}
          alt="logo"
        />
        <Image src="/HakimHub.png" width={181} height={50} alt="hakim-hub" />
      </section>

      <section className="flex">
        <Image
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
