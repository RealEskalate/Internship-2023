import avatar from '../../public/image/doctors/avatar.svg';
import hakimHub from '../../public/image/doctors/hackimhub.svg';
import Image from "next/image";


const Navbar = () => {
    return (
        <nav className="flex items-center justify-between bg-white p-4">
            <div className="flex items-center">
                <Image src={hakimHub} alt="Navbar Icon" />
            </div>
            <div className="flex items-center">
                <p className="mr-4">John Doe</p>
                <Image src={avatar} alt="Profile Photo" className="w-8 h-8 rounded-full" />
            </div>
        </nav>
    );
};

export default Navbar;