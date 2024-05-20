import Link from "next/link";
import { AiOutlineRight } from "react-icons/ai";
import {
  RiFacebookCircleLine,
  RiInstagramLine,
  RiTelegramLine,
  RiTwitterLine,
} from "react-icons/ri";

const Footer: React.FC = () => {
  return (
    <div className="bg-primary grid px-6 sm:px-0 text-white grid-cols-1 sm:grid-cols-7 w-full mt-auto pt-20">
      <div className="text-3xl font-bold sm:col-span-4 px-6">HakimHub</div>
      <div className="col-span-1 pb-16">
        <h3 className="text-lg font-semibold pb-3">Get Connected</h3>
        <div className="flex flex-col space-y-3">
          <div className="flex items-center space-x-1">
            <AiOutlineRight className="text-sm" />
            <p> For Physicians</p>
          </div>
          <div className="flex items-center space-x-1">
            <AiOutlineRight className="text-sm" />
            <p> For Physicians</p>
          </div>
        </div>
      </div>
      <div className="col-span-1 pb-16">
        <h3 className="text-lg font-semibold pb-3">Action</h3>
        <div className="flex flex-col space-y-3">
          <div className="flex items-center space-x-1">
            <AiOutlineRight className="text-sm" />
            <p>Find a Doctor</p>
          </div>
          <div className="flex items-center space-x-1">
            <AiOutlineRight className="text-sm" />
            <p>Find a Hospital</p>
          </div>
        </div>
      </div>
      <div className="col-span-1 pb-16">
        <h3 className="text-lg font-semibold pb-3">Company</h3>
        <div className="flex flex-col space-y-3">
          <div className="flex items-center space-x-1">
            <AiOutlineRight className="text-sm" />
            <p> About us</p>
          </div>
          <div className="flex items-center space-x-1">
            <AiOutlineRight className="text-sm" />
            <p> Career</p>
          </div>
          <div className="flex items-center space-x-1">
            <AiOutlineRight className="text-sm" />
            <p> Join our team</p>
          </div>
        </div>
      </div>
      <div className="sm:col-span-7 flex border-t justify-between p-4">
        <div className="flex flex-col sm:flex-row sm:space-x-8 text-lg font-bold">
          <p>Privacy Policy</p>
          <p>Terms of use</p>
        </div>
        <div className="flex flex-col sm:flex-row text-2xl sm:space-x-16">
          <Link href="/">
            <RiTelegramLine />
          </Link>
          <Link href={"/"}>
            <RiInstagramLine />
          </Link>
          <Link href={"/"}>
            <RiTwitterLine />
          </Link>

          <Link href={"/"}>
            <RiFacebookCircleLine />
          </Link>
        </div>
      </div>
    </div>
  );
};

export default Footer;
