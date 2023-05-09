import BuildBetter from '@/components/home/BuildBetter'
import HelpUs from '@/components/home/HelpUs'
import Landing from '@/components/home/Landing'
import Services from '@/components/home/Services'
import SuccessRate from '@/components/home/SuccessRate'

export default function Home() {
  return (
    <main className="bg-white flex min-h-screen flex-col justify-between">
      <Landing />
      <BuildBetter />
      <SuccessRate />
      <Services />
      <HelpUs />
    </main>
  )
}
