import React, { useState, useEffect } from 'react'
import { LoadingSpinner } from '@/components/common/LoadingSpinner'
import { Pagination } from '@/components/common/Pagination'
import DoctorCard from '@/components/doctor/DoctorCard'
import { useSearchDoctorsQuery } from '@/store/doctors/doctors-api'

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
  } = useSearchDoctorsQuery(debouncedSearchInput)

  const handleSearchInputChange = (event: React.ChangeEvent<HTMLInputElement>) => {
    setSearchInput(event.target.value)
  }

  if (searchLoading) {
    return <LoadingSpinner />
  }

  if (searchSuccess) {
    return (
      <div>
        {/* Search bar */}
        <form className="flex gap-4 justify-center mt-12">
          <input
            type="text"
            className="border border-gray-300 text-gray-900 text-sm rounded-full block px-8 py-2.5 w-2/3"
            placeholder="Name"
            value={searchInput}
            onChange={handleSearchInputChange}
          />
        </form>

      {/* Doctor card list */}
      <div className='grid grid-cols-4 gap-16 my-16'>
        { searchData.data.map((doctor, index) => <DoctorCard key={index} doctor={doctor} />) }
      </div>

      {/* Pagination */}
      <Pagination numberOfPages={8} />
      </div>
    )
  }

  return <div>{searchError ? searchErrorData.toString() : "Unknown Error"}</div>
}

export default HomeScreen;