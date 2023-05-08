import Link from "next/link";
import Image from "next/image"

interface HeaderProps {
  activePage: string;
}

function Navbar({ activePage }: HeaderProps) {
  return (
    <nav className="bg-white text-secondary-text">
     
          <div  className="flex mt-2 justify-between">
            
            <div className="ml-2">
              <Link href="/" >
                  <Image width={60}  height={60} className="primary-text" src="/img/a2sv-logo.jpeg" alt="Logo" />
              </Link>
            </div>

           {/* Navbar  */}
            <div className="hidden justify-center sm:block sm:ml-28  ">
              <ul className="flex space-x-4 secondary-text">

                <HeaderLink  href="/" active={activePage === "home"}>
                  Home
                </HeaderLink>

                <HeaderLink href="/teams" active={activePage === "teams"}>
                  Teams
                </HeaderLink>

                <HeaderLink href="/success-stories" active={activePage === "success-stories"} >
                  Success Stories
                </HeaderLink>

                <HeaderLink href="/about-us" active={activePage === "about-us"}>
                  About Us
                </HeaderLink>

                <HeaderLink href="/blogs" active={activePage === "blogs"}>
                  Blogs
                </HeaderLink>

                <HeaderLink href="/get-involved" active={activePage === "get-involved"}>
                  Get Involved
                </HeaderLink>
                </ul>
            </div>

               {/* Buttons Login and Donate */}
                <div className="justify-end mr-8 mt-1 ">
                    <Link href="/login" className="px-3 py-2 rounded-md bg-white text-sm font-medium hover:text-white hover:bg-secondary-text focus:outline-none focus:text-white focus:bg-secondary-text">
                        Login
                    </Link>

                    <Link href="/donate" className="px-3 py-2 rounded-md bg-primary text-sm font-medium hover:text-white hover:bg-red focus:outline-none focus:text-white focus:bg-secondary-text">
                        Donate
                    </Link>
                </div>
      </div>
    </nav>
  );
}

interface HeaderLinkProps {
  href: string;
  active: boolean;
  children: React.ReactNode;
}

function HeaderLink({ href, active, children }: HeaderLinkProps) {

  const activeClasses = active ? "bg-blue text-white" : "text-black";
  
  return (
    <li className="flex">
      <Link href={href} className={`px-3 py-2 rounded-md text-sm font-medium ${activeClasses} hover:text-white hover:bg-secondary-text focus:outline-none focus:text-white focus:bg-secondary-text`}>
          {children}
      </Link>
    </li>
  );
}

export default Navbar;