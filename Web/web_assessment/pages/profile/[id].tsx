import { LoadingSpinner } from '@/components/common/LoadingSpinner'
import { useGetDoctorByIdQuery } from '@/store/doctors/doctors-api'
import { useRouter } from 'next/router'

const ProfileScreen = () => {
  const router = useRouter()
  const id = router.query.id as string

  const { data, isSuccess, isLoading, isError, error } = useGetDoctorByIdQuery(id)

  if (isLoading) {
    return <LoadingSpinner />
  }

  if (isSuccess) {
    return <div>{data.fullName}</div>
  }

  return <div>{isError ? error.toString() : "Unknown Error"}</div>
}

export default ProfileScreen;