import Image from 'next/image'
import { Inter } from 'next/font/google'
import SingleDoctor from '@/components/doctors/SingleDoctor'
import { useGetDoctorsQuery } from '@/store/features/doctors/doctors-api'
import DoctorList from '@/components/doctors/DoctorList'




const Home: React.FC = () => {
  // const { data: doctors = [], isFetching, isError } = useGetDoctorsQuery({})
  // console.log(doctors)
  return (
    <div className="min-h-screen bg-white font-{poppins} scroll-smooth">
      <SingleDoctor />
      <DoctorList />
    </div>
  )
}
export default Home
