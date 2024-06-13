import Image from "next/image";
import Link from "next/link";
import { useState } from "react";
import logo from "@/public/img/hackimhub.svg";
import avatar from "@/public/img/avatar.svg";
import { AiOutlineDown } from "react-icons/ai";

const Navbar: React.FC = () => {
  const [toggle, setToggle] = useState(false);
  const [active, setActive] = useState("/");
  const setActiveAndToggle = (current: string) => {
    setActive(current);
    setToggle(!toggle);
  };
  return (
    <div className="sticky top-0 z-50 bg-white bg-opacity-100 flex justify-between px-5 pt-5">
      <Link href="/" onClick={() => setActive("/")}>
        <Image src={logo} alt="Hakim Hub" className="h-12 w-25 my-auto" />
      </Link>

      <div className="hidden md:flex gap-4 my-5">
        <Image src={avatar} alt={""} />
        <h4 className="my-auto">Johnatan Alemayehu</h4>
        <AiOutlineDown width={100} className="my-auto" />
      </div>
    </div>
  );
};

export default Navbar;
