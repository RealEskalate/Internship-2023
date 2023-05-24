import Navbar from "@component/home/Navbar"
import HomePage from "@component/home/HomePage";
import CardCollection from "@compnents/home/DoctorCard" 
import DoctorsProfile from "@component/home/Profile";


const HomePage: React.FC = () => {
  return (
    <div className="container mx-auto">
      <Navbar/> 
      <HomePage/>
      <CardCollection/>
      <DoctorsProfile/>
    </div>
  );
};

export default HomePage;