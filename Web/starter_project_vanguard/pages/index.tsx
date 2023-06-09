import HeroSection from '@/components/home/HeroSection'
import BuildBetter from '@/components/home/BuildBetter'
import SuccessRate from '@/components/home/SuccessRate'
import HelpUs from '@/components/home/HelpUs'
import ImpactStories from '@/components/home/ImpactStories'

const Home: React.FC = () => {
  return (
    <div className="min-h-screen bg-white font-{poppins} scroll-smooth">
      <HeroSection />
      <BuildBetter />
      <SuccessRate />
      <HelpUs />
      <ImpactStories />
    </div>
  )
}
export default Home
