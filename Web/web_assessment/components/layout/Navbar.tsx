import Image from 'next/image'
import Link from 'next/link'
import logo from '../../public/img/logo.jpg'

const Navbar: React.FC = () => {  return (
    <div className="mb-auto w-full flex justify-between items-center sm:px-10 pt-5">
      <Link href="/" >
        <Image src={logo} alt="hakimup Logo" className="w-44 " />
      </Link>
      <div className="flex text-gray-600 items-center space-x-4">
        <div className='h-14 w-14 rounded-full bg-primary'></div>
        <p className='text-lg'>Johnathan Alemayehu</p>
      </div>
      
    </div>
  );
};

export default Navbar;
