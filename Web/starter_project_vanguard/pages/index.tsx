import Image from 'next/image'
import { SuccessModel } from '@/types/home/SuccessModel';
import { Activity } from '@/types/home/Activity';
import HeroSection from '@/components/home/HeroSection'
import BuildBetter from '@/components/home/BuildBetter'
import SuccessRate from '@/components/home/success-components/SuccessRate'
import HelpUs from '@/components/home/HelpUs';
import ImpactStroies from '@/components/home/ImpactStories';

interface Props {
  infos: SuccessModel[];
  activities: Activity[];
}

export default function Home({ infos, activities } : Props) {
  return (
    <div className="min-h-screen bg-white font-{poppins} scroll-smooth">
      <HeroSection />
      <BuildBetter/>
      <SuccessRate infos = {infos} activities = {activities}/>
      <HelpUs/>
      <ImpactStroies/>
    </div>
  )
}
