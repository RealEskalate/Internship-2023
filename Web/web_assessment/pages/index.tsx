import Image from "next/image";
import { Inter } from "next/font/google";
import SearchBar from "@/components/common/SearchBar";
import DoctorList from "@/components/doctor/DoctorList";
import Footer from "@/components/layout/Footer";
import Navigation from "@/components/layout/Navigation";
import HospitalCard from "@/components/web/HospitalCard";
import HospitalList from "@/components/web/HospitalList";
import HospitalDetails from "@/components/web/HospitalDetail";

const inter = Inter({ subsets: ["latin"] });

export default function Home() {
  return (
    <div className="min-h-screen bg-white ">
      <div className="p-20">
        <HospitalList />
      </div>
    </div>
  );
}
