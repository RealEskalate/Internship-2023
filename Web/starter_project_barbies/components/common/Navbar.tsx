import Link from "next/link";
import Image from "next/image";
import { useRouter } from "next/router";


interface NavbarLink {
  href: string;
  active: boolean;
  children: React.ReactNode;
}

const Navbar: React.FC = () => {
  const location = useRouter();
  const navbarLinks: NavbarLink[] = [
    { href: "/", active: location.pathname=== "/", children: "Home" },
    { href: "/team", active: location.pathname=== "/team", children: "Teams" },
    { href: "/story", active: location.pathname=== "/story", children: "Success Stories" },
    { href: "/about", active: location.pathname=== "/about", children: "About Us" },
    { href: "/blogs", active: location.pathname=== "/blogs", children: "Blogs" },
    { href: "/get-involved", active: location.pathname=== "/get-involved", children: "Get Involved" }
  ];

  return (
    <nav className="bg-white text-secondary-text">
      <div className="flex mt-2 items-center justify-between">

          <Link href="/">
            <Image width={60} height={60} className="  w- h-20 primary-text ml-6" src="/img/a2sv-logo.jpeg" alt="Logo" />
          </Link>
     

        <div className="hidden justify-center sm:block sm:ml-28">
          <ul className="flex space-x-4 secondary-text">
            {navbarLinks.map(({ href, active, children }, index) => (
              <HeaderLink key={index} href={href} active={active}>
                {children}
              </HeaderLink>
            ))}
          </ul>
        </div>

        <div className="justify-end mr-8 mt-1 sm:block hidden">
          <Link href="/login" className="px-3 py-2 rounded-md bg-white text-sm font-medium hover:text-blue-400 hover:bg-secondary-text focus:outline-none focus:text-white focus:bg-secondary-text">
            Login
          </Link>

          <Link href="/donate" className="px-3 py-2 rounded-md bg-primary text-sm font-medium hover:text-white hover:bg-red focus:outline-none focus:text-white focus:bg-secondary-text">
            Donate
          </Link>
        </div>
      </div>
    </nav>
  );
};

interface HeaderLinkProps {
  href: string;
  active: boolean;
  children: React.ReactNode;
}

const HeaderLink: React.FC<HeaderLinkProps> = ({ href, active, children }) => {
  const activeClasses = active ? "bg-blue text-white" : "bg-white text-black";

  return (
    <li className="flex">
      <Link href={href} className={`hover:bg-blue-600 px-3 py-2 rounded-md text-sm font-medium ${activeClasses}  hover:bg-secondary-text focus:outline-none focus:text-white focus:bg-secondary-text`}>
        {children}
      </Link>
    </li>
  );
};

export default Navbar;
