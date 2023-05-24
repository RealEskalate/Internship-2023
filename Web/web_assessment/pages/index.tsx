import Doctor from '@/components/Doctor'
import { useFetchDoctorWithPaginationMutation, useSearchDoctorsMutation } from '@/store/doctor/doctor-api'
import Image from 'next/image'
import Link from 'next/link'
import { useEffect, useState } from 'react'
import { BiSearch} from 'react-icons/bi'

export default function Home() {
  const [query, setQuery] = useState('')
  const [page, setPage] = useState(1)
  const [skip, setSkip] = useState(true)
  const [doctors, setDoctors] = useState<any>([])
  const [fetchPagination] = useFetchDoctorWithPaginationMutation()
  const [searchDoctors] = useSearchDoctorsMutation()
  const fetch = async () => {
    try {
      const data = await fetchPagination(page).unwrap()
      setDoctors(data.data)
    } catch (error) {
      console.log(error)
    }

  }
  const fetchWithQuery = async () => {
    try {
      const data = await searchDoctors(query).unwrap()
      console.log(data)
      setDoctors(data.data)
    } catch (error) {
      console.log(error)
    }
  }
  useEffect(() => { 
    fetch()
  },[])
  useEffect(() => {
    const fetch = async () => {
      try {
        const data = await searchDoctors(query).unwrap()
        setDoctors(data.data)
      } catch (error) {
        console.log(error)
      }

    }
    if (query){
      fetch()
    }else{
      fetchWithQuery()
    }

  },[query])
  useEffect(() => {
    if(!query){
      fetch()
    }
  },[query, page])
  
  return (
    <div className='flex flex-col'>
      <div className='flex items-center mx-auto'>
        <input type="text" className='w-96 px-10 py-2 rounded-full border border-gray-300' onChange={(e)=>setQuery(e.target.value)}/>
        <BiSearch color='gray-300' className='-ml-10' />
      </div>

      <div className='flex flex-wrap gap-5 max-w-7xl mx-auto mt-10 h-screen'>
        { doctors?.map((doctor:any, index:number) => (
          <Link href={`/${doctor._id}`}>
            <Doctor key={index} doctor={doctor}/>
          </Link>
        ))}
      </div>
      <div className='flex gap-5 self-center items-center mt-10'>
        <button className='bg-blue-500 px-5 py-2 text-white rounded-lg' onClick={() => page > 0 && setPage(page - 1)}>previous</button>
        <div>{page}</div>
        <button className='bg-blue-500 px-5 py-2 text-white rounded-lg' onClick={()=> setPage(page + 1)}>Next</button>

      </div>
    </div>


  )
}
