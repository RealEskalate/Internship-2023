import React from "react";

const Footer: React.FC = () => {

    return (
        <footer className="bg-indigo-800 text-white p-4">
            <div className="container mx-auto grid grid-cols-3 gap-4">
                <div>
                    <h3 className="text-2xl font-bold mb-4">HakimHub</h3>
                </div>

                <div>
                    <h3 className="text-xl mb-4">Get Connected</h3>
                    <ul>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">For Physicians</a>
                        </li>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">For Hospitals</a>
                        </li>
                    </ul>
                </div>

                <div>
                    <h3 className="text-lg font-bold mb-4">Actions</h3>
                    <ul>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Find a Doctor</a>
                        </li>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Find a Hospital</a>
                        </li>
                    </ul>
                </div>

                <div>
                    <h3 className="text-lg font-bold mb-4">Company</h3>
                    <ul>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Join Us</a>
                        </li>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Career</a>
                        </li>
                        <li className="mb-2">
                            <a href="#" className="hover:text-blue-500">Our Team</a>
                        </li>
                    </ul>
                </div>
            </div>
        </footer>

    );
};

export default Footer;
