import { LoadingSpinner } from '@/components/common/LoadingSpinner'
import { Pagination } from '@/components/common/Pagination'
import DoctorCard from '@/components/doctor/DoctorCard'
import { useGetDoctorsQuery } from '@/store/doctors/doctors-api'

const HomeScreen = () => {
  const { data, isSuccess, isLoading, isError, error } = useGetDoctorsQuery()

  if (isLoading) {
    return <LoadingSpinner />
  }

  if (isError) {
    return <div>{error.toString()}</div>
  }

  if (isSuccess) {
    return <div>
      {/* Search bar */}
      <form className="flex gap-4 justify-center mt-12">
        <input type="text" className="border border-gray-300 text-gray-900 text-sm rounded-full block px-8 py-2.5 w-2/3" placeholder="Name" />
      </form>

      {/* Doctor card list */}
      <div className='grid grid-cols-4 gap-16 my-16'>
        { data.data.map((doctor, index) => <DoctorCard key={index} doctor={doctor} />) }
      </div>

      {/* Pagination */}
      <Pagination numberOfPages={8} />
    </div>
  }

  return <div>hello home</div>
}

export default HomeScreen;