// Footer.tsx
import React from "react";
import Link from "next/link";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

const Footer: React.FC = () => {
  return (
    <nav className="flex justify-center bg-gray-200 py-4">
      <ul className="flex space-x-4">
        <li>
          <Link href="">
            <p className="flex items-center text-gray-600 hover:text-gray-800">
              <FontAwesomeIcon icon="facebook" className="mr-1" />
              Facebook
            </p>
          </Link>
        </li>
        <li>
          <Link href="">
            <p className="flex items-center text-gray-600 hover:text-gray-800">
              <FontAwesomeIcon icon="instagram" className="mr-1" />
              Instagram
            </p>
          </Link>
        </li>
        <li>
          <Link href="">
            <p className="flex items-center text-gray-600 hover:text-gray-800">
              <FontAwesomeIcon icon="linkedin" className="mr-1" />
              LinkedIn
            </p>
          </Link>
        </li>
      </ul>
    </nav>
  );
};

export default Footer;
