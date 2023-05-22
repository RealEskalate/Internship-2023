import React from "react";
import Link from "next/link";
import Image from "next/image";

const Footer: React.FC = () => {
  const links = [
    { href: "/about", text: "Home" },
    { href: "/success-stories", text: "Success Stories" },
    { href: "/about-us", text: "About Us" },
    { href: "/get-involved", text: "Get Involved" }
  ];

  const teams = [
    { href: "/board-members", text: "Board Members" },
    { href: "/advisors-mentors", text: "Advisors Mentors" },
    { href: "/executives", text: "Executives" },
    { href: "/staffs", text: "Staffs" }
  ];

  const blogLinks = [
    { href: "/recent-blogs", text: "Recent Blogs" },
    { href: "/new-blog", text: "New Blog" }
  ];

  return (
    <footer className="bg-white border-black p-4">
      <div className="flex justify-between mt-4">
        <div className="flex items-center">
          <Image
            src="/img/footerpic.png"
            alt="Footer Logo"
            height={150}
            width={150}
            className="h-10 text-stone-950 mr-12"
          />
          <div>
            <h3 className="text-stone-950">Get Involved in improving tech</h3>
            <h3 className="mb-4 text-stone-950">education in africa!</h3>
            <button className="bg-blue-500 text-white px-4 py-2 rounded">
              Support Us
            </button>
          </div>
        </div>

        <div>
          <h3 className="text-lg font-bold mb-4 text-stone-950">Links</h3>
          <ul>
            {links.map((link, index) => (
              <li key={index} className="mb-4">
                <Link href={link.href} className="text-stone-950 hover:text-blue-500 pd-6">
                  {link.text}
                </Link>
              </li>
            ))}
          </ul>
        </div>

        <div>
          <h3 className="text-lg font-bold text-stone-950 mb-4">Teams</h3>
          <ul>
            {teams.map((team, index) => (
              <li key={index} className="mb-4">
                <Link href={team.href} className="text-stone-950 hover:text-blue-500">
                  {team.text}
                </Link>
              </li>
            ))}
          </ul>
        </div>

        <div>
          <h3 className="text-lg font-bold mb-4 text-stone-950">Blog</h3>
          <ul>
            {blogLinks.map((blogLink, index) => (
              <li key={index} className="mb-4">
                <Link href={blogLink.href} className="text-stone-950 hover:text-blue-500">
                  {blogLink.text}
                </Link>
              </li>
            ))}
          </ul>
        </div>
      </div>

      {/* Footer Copyright */}
      <div className="sm:flex sm:items-center sm:justify-between">
        <span className="text-sm text-black sm:text-center dark:text-black">
          © <a href="/" className="hover:underline">2020 Africa To Silicon Valley. Inc</a>. All Rights Reserved.
        </span>
        <div className="flex mt-4 space-x-6 pr-4 pb-6 pt-2 sm:justify-center sm:mt-0">
          <Link href="#" className="text-black hover:text-gray-900 dark:hover:text-white">
            <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true"></svg>
            <span className="sr-only">Twitter page</span>
          </Link>
          <Link href="#" className="text-black hover:text-gray-900 dark:hover:text-white">
            <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true">
              <path fillRule="evenodd" clipRule="evenodd" />
            </svg>
            <span className="sr-only">Facebook page</span>
          </Link>
          <Link href="#" className="text-black hover:text-gray-900 dark:hover:text-white">
            <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true">
              <path fillRule="evenodd" clipRule="evenodd" />
            </svg>
            <span className="sr-only">Instagram page</span>
          </Link>
          <Link href="#" className="text-black hover:text-gray-900 dark:hover:text-white">
            <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true">
              <path fillRule="evenodd" clipRule="evenodd" />
            </svg>
            <span className="sr-only">GitHub account</span>
          </Link>
          <Link href="#" className="text-black hover:text-gray-900 dark:hover:text-white">
            <svg className="w-5 h-5" fill="currentColor" viewBox="0 0 24 24" aria-hidden="true">
              <path fillRule="evenodd" clipRule="evenodd" />
            </svg>
            <span className="sr-only">Dribbble account</span>
          </Link>
        </div>
      </div>
    </footer>
  );
};

export default Footer;
