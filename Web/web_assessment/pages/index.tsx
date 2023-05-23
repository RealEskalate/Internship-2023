import Image from 'next/image'
import { Inter } from 'next/font/google'
import SingleDoctor from '@/components/doctors/SingleDoctor'
import { useGetDoctorsQuery } from '@/store/features/doctors/doctors-api'
import DoctorList from '@/components/doctors/DoctorList'
// import Footer from '@/components/layout/Footer'
// import Navbar from '@/components/layout/Navbar'




const Home: React.FC = () => {
  // const { data: doctors = [], isFetching, isError } = useGetDoctorsQuery({})
  // console.log(doctors)
  return (
    <div className="min-h-screen bg-white font-{poppins} scroll-smooth">
      {/* <Navbar /> */}
      <SingleDoctor />
      <DoctorList />
      {/* <Footer /> */}
    </div>
  )
}
export default Home
