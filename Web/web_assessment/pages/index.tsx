import DoctorList from '@/components/doctors/DoctorList'
import NavigationBar from '@/components/layout/Navbar'
import Footer from '@/components/layout/Footer'
import Pagination from '@/components/common/pagination'
// index.tsx or _app.tsx
import { library } from '@fortawesome/fontawesome-svg-core';
import { faFacebook, faInstagram, faLinkedin } from '@fortawesome/free-brands-svg-icons';

library.add(faFacebook, faInstagram, faLinkedin);


library.add(faFacebook, faInstagram, faLinkedin);



const Home: React.FC = () => {
  
  return (
    <div className="min-h-screen bg-white font-{poppins} scroll-smooth">
      <DoctorList />
    </div>
  )
}
export default Home
