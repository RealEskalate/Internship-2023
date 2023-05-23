import { useFetchDoctorQuery } from '@/store/doctor/doctor-api'
import { useRouter } from 'next/router'
import Image from 'next/image'

type Props = {}

const DoctorPage = (props: Props) => {
    const route = useRouter()
    const id = route.query.id 
    const {data:doctor} = useFetchDoctorQuery(id as string)
  return (
    <div>
      <div className="relative w-48 h-48 mx-auto">
        <Image className="rounded-full border-4 border-blue-500" src={doctor?.photo} fill={true} alt="profile picture"/>
      </div>
      <div className='font-bold text-4xl'>{doctor?.fullName}</div>
      <div className='font-bold text-2xl'>About</div>
      <div>{doctor?.summary}</div>
    </div>
  )
}

export default DoctorPage