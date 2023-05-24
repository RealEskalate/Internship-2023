import DoctorList from '@/components/doctors/DoctorList'
import NavigationBar from '@/components/layout/Navbar'
import Footer from '@/components/layout/Footer'
import Pagination from '@/components/common/pagination'




const Home: React.FC = () => {
  
  return (
    <div className="min-h-screen bg-white font-{poppins} scroll-smooth">
      <DoctorList />
    </div>
  )
}
export default Home
