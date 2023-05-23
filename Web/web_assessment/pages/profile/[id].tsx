import { LoadingSpinner } from '@/components/common/LoadingSpinner'
import { useGetDoctorByIdQuery } from '@/store/doctors/doctors-api'
import { useRouter } from 'next/router'
import Image from "next/image";

const ProfileScreen = () => {
  const router = useRouter()
  const id = router.query.id as string

  const { data: doctor, isSuccess, isLoading, isError, error } = useGetDoctorByIdQuery(id)

  if (isLoading) {
    return <LoadingSpinner />
  }

  if (isSuccess) {
    return <div className='flex flex-col items-center'>
      <div className="rounded-full border-4 border-primary">
        <Image src={doctor.photo} alt="Image" width={128} height={128} className="object-cover object-center rounded-full" />
      </div>

      <div className='ml-36 grid grid-cols-5 w-screen mr-180'>
        <div className='grid grid-cols-2 col-span-4'>
          <div className='flex flex-col'>
            <div className="text-2xl font-bold">
              {doctor.fullName}
            </div>
            <div>
              {doctor.speciality[0].name}
            </div>
          </div>
          <div className='mt-8'>
            {doctor.institutionID_list[0].institutionName}
          </div>
        </div>

        <div className="col-span-1" />

        <div className='mt-24 col-span-5'>
          <div>
            About
          </div>
          <div>
            {doctor.summary}
          </div>
        </div>

        <div className='mt-24 col-span-5'>
          <div>Education</div>
          <div>
            {/* None of the response objects have any education so I can't tell what how object is structured */}
          </div>
        </div>

        <div className='mt-24 col-span-5'>
          <div>Contact Info</div>
          <div>
            {/* None of the response objects have any emails so I can't tell what how object is structured */}
          </div>
        </div>

      </div>

    </div>
  }

  return <div>{isError ? error.toString() : "Unknown Error"}</div>
}

export default ProfileScreen;