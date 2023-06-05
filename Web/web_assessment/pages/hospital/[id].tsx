import { LoadingSpinner } from '@/components/common/LoadingSpinner'
import { useGetHospitalByIdQuery } from '@/store/hospitals/hospitals-api'
import { useRouter } from 'next/router'
import Image from "next/image";
import { FaPhone } from 'react-icons/fa';

const ProfileScreen = () => {
  const router = useRouter()
  const id = router.query.id as string

  const { data: hospital , isSuccess, isLoading, isError, error } = useGetHospitalByIdQuery(id)

  if (isLoading) {
    return <LoadingSpinner />
  }

  if (isSuccess) {
      return (
        <div>
         <Image src={hospital.coverPhoto} alt="Image" width={800} height={600} className="object-cover object-center rounded-e-md" />
    
          <h1 className="text-lg font-bold my-3">{hospital.institutionName}</h1>
          <div className="flex">
            <p className="bg-green-500 rounded-full mx-2 h-1/3">{hospital.status}</p>
            <p className="bg-blue-500 rounded-full h-1/2">{hospital.availability.twentyFourHours}</p>
          </div>
          <p className='my-3 text-sm font-light'>{hospital.summary}
          </p>
          <h1 className="text-lg font-bold my-3">Services</h1>
          <h1 className="text-lg font-bold my-3">Services</h1>
      <ul className="flex-col flex-wrap list-disc list-inside text-lg">
      <li className="relative">
        <span className="absolute left-0 top-1/2 transform -translate-y-1/2 h-2 w-2 bg-purple-600 rounded-full"></span>
        <span className="ml-4 text-black">Ambulatory Surgical Facility</span>
      </li>
      <li className="relative">
        <span className="absolute left-0 top-1/2 transform -translate-y-1/2 h-2 w-2 bg-purple-600 rounded-full"></span>
        <span className="ml-4 text-black">Urgent Care clinic</span>
      </li>
      <li className="relative">
        <span className="absolute left-0 top-1/2 transform -translate-y-1/2 h-2 w-2 bg-purple-600 rounded-full"></span>
        <span className="ml-4 text-black">Orthopedic Rehabilitation Center</span>
      </li>
      <li className="relative">
        <span className="absolute left-0 top-1/2 transform -translate-y-1/2 h-2 w-2 bg-purple-600 rounded-full"></span>
        <span className="ml-4 text-black">Hospice Homes</span>
      </li>
      <li className="relative">
        <span className="absolute left-0 top-1/2 transform -translate-y-1/2 h-2 w-2 bg-purple-600 rounded-full"></span>
        <span className="ml-4 text-black">Ambulatory Surgical Facility</span>
      </li>
      <li className="relative">
        <span className="absolute left-0 top-1/2 transform -translate-y-1/2 h-2 w-2 bg-purple-600 rounded-full"></span>
        <span className="ml-4 text-black">Urgent Care clinic</span>
      </li>
      <li className="relative">
        <span className="absolute left-0 top-1/2 transform -translate-y-1/2 h-2 w-2 bg-purple-600 rounded-full"></span>
        <span className="ml-4 text-black">Orthopedic Rehabilitation Center</span>
      </li>
      <li className="relative">
        <span className="absolute left-0 top-1/2 transform -translate-y-1/2 h-2 w-2 bg-purple-600 rounded-full"></span>
        <span className="ml-4 text-black">Hospice Homes</span>
      </li>
    </ul>
          {/* i would have rather displyed the services taking it as an array */}
         
      <h1 className="text-lg font-bold my-3">Contact Details</h1>
      <div>
        <div className='flex flex-wrap gap-5'>
        <FaPhone />
        <p>Main Office</p>
          </div>
        
        <p>+345678</p>
        <p>+345678</p>
      </div>
      <div>
      <div  className='flex flex-wrap gap-5'>
      <FaPhone />
      <p>
        Laboratory Office</p>
        </div>
        
        <p>+345678</p>
        <p>+345678</p>
      </div>

    </div>
      )
    }
    
    
  

  return <div>{isError ? error.toString() : "Unknown Error"}</div>
}

export default ProfileScreen;