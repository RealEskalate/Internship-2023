import React, { ReactNode } from 'react'
import Navbar from "@/components/common/NavBar";
import Footer from "@/components/common/Footer";

interface LayoutProps {
    children : ReactNode
}
const Layout = ({ children }: LayoutProps) => {
    return (
        <div className="flex flex-col min-h-screen bg-white">
            <Navbar />
            <div className="flex-grow">{children}</div>
            <Footer />
        </div>
    );
};

export default Layout;