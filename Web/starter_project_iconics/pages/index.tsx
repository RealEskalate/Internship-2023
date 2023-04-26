import BuildBetter from '@/components/home/BuildBetter'
import Landing from '@/components/home/Landing'

export default function Home() {
  return (
    <main className="flex min-h-screen flex-col justify-between">
      <Landing />
      <BuildBetter />
    </main>
  )
}
