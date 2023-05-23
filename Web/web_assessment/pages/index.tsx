import DoctorDetail from "@/components/home/DoctorDetail";
import { Doctor } from "@/types/doctor";
import doctor from "../data/doctor/doctors.json";
export default function Home() {
  const profile: Doctor = JSON.parse(JSON.stringify(doctor))[0];
  return (
    <main className="bg-white flex flex-col">
      <DoctorDetail doctor={profile} />
    </main>
  );
}
