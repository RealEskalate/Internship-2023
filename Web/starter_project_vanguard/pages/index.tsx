
import Image from 'next/image'
import Landing from '@/components/home/Landing_section/Landing'
import Better from '@/components/home/Better_section/Better'


export default function Home() {
  return (
    <div className='bg-white min-h-screen font-body'>
      <Landing/>
      <Better/>
    </div>
  )
}
