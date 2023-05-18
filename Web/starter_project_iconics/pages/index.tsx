import BuildBetter from '@/components/home/BuildBetter'
import HelpUs from '@/components/home/HelpUs'
import ImpactStories from '@/components/home/ImpactStories'
import Landing from '@/components/home/Landing'
import Services from '@/components/home/Services'
import SuccessRate from '@/components/home/SuccessRate'

export default function Home() {
  return (
    <main className="bg-white flex flex-col">
      <Landing />
      <BuildBetter />
      <SuccessRate />
      <Services />
      <HelpUs />
      <ImpactStories />
    </main>
  )
}
