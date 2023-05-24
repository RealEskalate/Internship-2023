import DoctorCard from "@/components/DoctorCard"
import DoctorList from "@/components/DoctorList"

export default function Home() {
  return (
   <div className="min-h-screen bg-white">
    {/* <DoctorCard photoUrl="/img/tree.jpg" name="rediet ferew" specialty="pedrasan" address="addis ababa"/> */}
    <DoctorList/>
   </div>
      
  )
}