import React from "react";

const Footer = () => {
  return (
    <footer className="bg-blue-800 text-white py-4">
      <div className="container mx-auto flex justify-center">
        <ul className="flex space-x-4">
          <li>
            <a href="#" className="hover:text-gray-200">
              Home
            </a>
          </li>
          <li>
            <a href="#" className="hover:text-gray-200">
              About
            </a>
          </li>
          <li>
            <a href="#" className="hover:text-gray-200">
              Services
            </a>
          </li>
          <li>
            <a href="#" className="hover:text-gray-200">
              Contact
            </a>
          </li>
        </ul>
      </div>
    </footer>
  );
};

export default Footer;
