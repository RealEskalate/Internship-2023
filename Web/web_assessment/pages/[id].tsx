import { useGetDoctorByIdQuery } from '@/store/doctor/doctors-api'
import { useRouter } from 'next/router';


const DoctorDetail = () => {
  const router = useRouter()
  const blogID = router.query.id as string

  const { data:doctor, isSuccess, isLoading, isError, error } = useGetDoctorByIdQuery(blogID)
  console.log(doctor)
  console.log(blogID)

  if (isLoading) {
    return <div>Loading...</div>
  }
  
  if (isError) {
    return <div>{error.toString()}</div>
  }
  
  if (isSuccess) {
    //

    return (
      <div className='bg-white text-black'>

        {/* add the doctor detail component here*/}

      </div>
    )
  }
}

export default DoctorDetail;
