import Image from "next/image";
import { Inter } from "next/font/google";
import DoctorsList from "./doctors-list";

const inter = Inter({ subsets: ["latin"] });

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col items-center justify-between p-24 bg-white">
      <DoctorsList />
    </main>
  );
}
