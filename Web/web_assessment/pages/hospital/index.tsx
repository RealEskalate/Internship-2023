import Image from "next/image";
import { Inter } from "next/font/google";
import HospitalList from "@/components/hospital/HospitalList";

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
