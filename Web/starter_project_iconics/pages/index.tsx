import BuildBetter from '@/components/home/BuildBetter'
import Landing from '@/components/home/Landing'

export default function Home() {
  return (
    <main className="bg-white flex min-h-screen flex-col justify-between">
      <Landing />
      <BuildBetter />
    </main>
  )
}
