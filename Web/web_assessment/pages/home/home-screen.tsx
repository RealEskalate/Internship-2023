import React, { useState, useEffect } from 'react'
import { LoadingSpinner } from '@/components/common/LoadingSpinner'
import { Pagination } from '@/components/common/Pagination'
import HospitalCard from '@/components/Hospital/HospitalCard'
import { useSearchHospitalQuery } from '@/store/hospitals/hospitals-api'
import { FaSearch } from 'react-icons/fa';

function useDebounce(value: any, delay: number) {
  const [debouncedValue, setDebouncedValue] = useState(value)

  useEffect(() => {
    const handler = setTimeout(() => {
      setDebouncedValue(value)
    }, delay)

    return () => {
      clearTimeout(handler)
    }
  }, [value, delay])

  return debouncedValue
}

const HomeScreen = () => {
  const [searchInput, setSearchInput] = useState('')
  const debouncedSearchInput = useDebounce(searchInput, 200)

  const {
    data: searchData,
    isSuccess: searchSuccess,
    isLoading: searchLoading,
    isError: searchError,
    error: searchErrorData,
  } =  useSearchHospitalQuery(debouncedSearchInput)

  const handleSearchInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchInput(event.target.value)
  }

  if (searchLoading) {
    return <LoadingSpinner />
  }

  if (searchSuccess) {
    return (
      <div>
        <form className="flex gap-4 justify-center mt-4 w-full">
      <div className="relative w-full">
        <span className="absolute left-3 top-3 text-gray-400">
          <FaSearch />
        </span>
        <input
          type="text"
          className="border border-gray-300 text-gray-900 text-sm rounded-md pl-10 pr-4 py-2 w-full"
          placeholder="Name"
          value={searchInput}
          onChange={handleSearchInputChange}
        />
        
      </div>
      <button className="bg-blue-500 text-white py-2 px-4 rounded-md hover:bg-blue-600 focus:outline-none focus:bg-blue-600">
        Search
      </button>
    </form>
  
     
      <div className='grid flex-cols-4 gap-16 my-20'>
        { searchData.data.map((hospital, index) => <HospitalCard key={index} hospital={hospital} />)}
      </div>

      <Pagination numberOfPages={8} />
      </div>
    )
  }

  return <div>{searchError ? searchErrorData.toString() : "Unknown Error"}</div>
}

export default HomeScreen;