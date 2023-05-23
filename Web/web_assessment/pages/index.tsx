import { useSearchDoctorsMutation } from '@/store/doctor/doctor-api'
import { useFetchDoctorWithPaginationMutation } from '@/store/doctor/doctor-api'
import { useFetchDoctorsMutation } from '@/store/doctor/doctor-api'
import Image from 'next/image'
import { useEffect, useState } from 'react'
import { BiSearch} from 'react-icons/all'

export default function Home() {
  const [query, setQuery] = useState('')
  const [page, setPage] = useState(1)
  const [fetchDoctors] = useFetchDoctorWithPaginationMutation()
  const [fetchDoctorQuery] = useSearchDoctorsMutation()
  const [doctors, setDoctors] = useState<any[]>([])
  useEffect(() => {
    const fetch = async () => {
      const docs = await fetchDoctors(page).unwrap()
      setDoctors(docs)
    }
    fetch()
  })
  useEffect(()=>{
    const fetch = async () => {
      const docs = await fetchDoctors(page).unwrap()
      setDoctors(docs)
    }
    fetch()
  }, [page])

  useEffect(()=>{
    const fetch = async () => {
      const docs = await fetchDoctorQuery(query).unwrap()
      setDoctors(docs)
    }
    if(query.length > 0){
      fetch()
    }
  },[query])
  
  return (
    <div>
      <div className='flex max-w-4xl mx-auto'>
        <input type="text" className='w-full px-10 py-2 rounded-full border border-gray-300' />
        <BiSearch color='gray-300' className='-ml-10' />
      </div>

      <div className='flex flex-wrap'>

      </div>
    </div>


  )
}
