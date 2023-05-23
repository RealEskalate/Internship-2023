import { useGetDoctorsQuery } from '@/store/doctors/doctors-api'

const HomeScreen = () => {
  const { data, isSuccess, isLoading, isError, error } = useGetDoctorsQuery()

  if (isLoading) {
    return <div>hello home</div>
  }

  if (isError) {
    return <div>{error.toString()}</div>
  }

  if (isSuccess) {
    return <div>
      { data.data.length }
    </div>
  }

  return <div>hello home</div>
}

export default HomeScreen;