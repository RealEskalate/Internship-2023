import Image from 'next/image'
import { Inter } from 'next/font/google'
import DoctorCard from '@/pages/doctordetail/[id]'
import DoctorsList from '@/components/DoctorsList'
import { useState } from 'react'
import { Input } from 'postcss'
import DoctorsSearch from '@/components/DoctorsSearch'

const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  const [search_query, setSearch_query] = useState("")
  return (
    <main className="">


      <div>
        <form className = "flex">
          <input className = " m-20 mx-36 border-2 p-2 border-lightblack w-full rounded-2xl" placeHolder = "Name" type = "text"  value = {search_query} onChange = {(e) => setSearch_query(e.target.value)}/>
        </form>
        {search_query ? <DoctorsSearch serachQuery= {search_query}/> : <DoctorsList></DoctorsList>}

        
      </div>
    </main>
  )
}
