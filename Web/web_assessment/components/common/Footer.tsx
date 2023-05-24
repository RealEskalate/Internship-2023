import React from "react";

const Footer: React.FC = () => {

    return (
        <footer className="bg-indigo-500 text-white p-4 py-12">
            <div className="container mx-auto grid grid-cols-2 gap-4">
                <div>
                    <h3 className="text-2xl font-bold mb-4">HakimHub</h3>
                </div>

                <div className="container mx-auto grid grid-cols-3 gap-2">
                    <div>
                        <h3 className="text-xl mb-4">Get Connected</h3>
                        <ul>
                            <li className="mb-2">
                                <a href="#" className="hover:text-blue-500">&gt; For Physicians</a>
                            </li>
                            <li className="mb-2">
                                <a href="#" className="hover:text-blue-500">&gt; For Hospitals</a>
                            </li>
                        </ul>
                    </div>

                    <div>
                        <h3 className="text-lg font-bold mb-4">Actions</h3>
                        <ul>
                            <li className="mb-2">
                                <a href="#" className="hover:text-blue-500">&gt; Find a Doctor</a>
                            </li>
                            <li className="mb-2">
                                <a href="#" className="hover:text-blue-500"> &gt;Find a Hospital</a>
                            </li>
                        </ul>
                    </div>

                    <div>
                        <h3 className="text-lg font-bold mb-4">Company</h3>
                        <ul>
                            <li className="mb-2">
                                <a href="#" className="hover:text-blue-500">&gt; Join Us</a>
                            </li>
                            <li className="mb-2">
                                <a href="#" className="hover:text-blue-500">&gt; Career</a>
                            </li>
                            <li className="mb-2">
                                <a href="#" className="hover:text-blue-500">&gt; Our Team</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </div>

            <hr className="mt-8"></hr>
        </footer>

    );
};

export default Footer;
