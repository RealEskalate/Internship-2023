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
        <footer className="bg-indigo-800 text-white p-4">
            <div className="container mx-auto flex justify-between items-center">
                <div>
                    <h3 className="text-2xl font-bold">HakimHub</h3>
                    <h3 className="text-xl mb-4">Get Connected</h3>
                    <ul>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Actions</a>
                        </li>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Company</a>
                        </li>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">For Physicians</a>
                        </li>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">For Hospitals</a>
                        </li>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Career</a>
                        </li>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Privacy Policy</a>
                        </li>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Terms of Use</a>
                        </li>
                    </ul>
                </div>

                <div>
                    <h3 className="text-lg font-bold mb-4">Find a doctor</h3>
                    <ul>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">About Us</a>
                        </li>
                    </ul>
                </div>

                <div>
                    <h3 className="text-lg font-bold mb-4">Find a hospital</h3>
                    <ul>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Join our team</a>
                        </li>
                    </ul>
                </div>
            </div>
        </footer>
    );
};

export default Footer;
