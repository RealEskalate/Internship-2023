import DoctorCard from "@/components/home/DoctorCard";
import { Inter } from "next/font/google";

const inter = Inter({ subsets: ["latin"] });
import HomePage from "./doctors/index";
export default function Home() {
  return (
    <main className="flex min-h-screen flex-col bg-gray-50 items-center justify-between">
      <HomePage />
    </main>
  );
}
