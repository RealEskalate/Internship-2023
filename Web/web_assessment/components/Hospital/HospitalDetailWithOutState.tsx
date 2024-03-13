import Image from 'next/image'
import blackLion from './../../public/img/blackLion.png'
import { FaPhone } from 'react-icons/fa';
const HospitalDetailWithOutState = () => {
  return (
    <div>
     <Image src={blackLion} alt="Image" width={1200} height={600} className="object-cover object-center rounded-e-md" />

      <h1 className="text-xl font-bold my-3">Black Lion Hospital</h1>
      <div className="flex">
        <p className="bg-green-500 rounded-full mx-2 h-1/3">Open Now</p>
        <p className="bg-blue-500 rounded-full h-1/2">Available 24 hours</p>
      </div>
      <p className='my-3 text-sm font-light'>The Hospital was built by Emperor Haile Selassie I in 1969 with the help of the German Evangelical Church. It aimed to serve the poor.
          The Hospital was built by Emperor Haile Selassie I in 1969 with the help of the German Evangelical Church. It aimed to serve the poor.
          The Hospital was built by Emperor Haile Selassie I in 1969 with the help of the German Evangelical Church. It aimed to serve the poor.
      </p>
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
      <div className='border-2 rounded-md my-5'>
      <h1 className="text-lg font-bold my-3 mx-5">Contact Details</h1>
      <div className='my-10 mx-10'>
        <div className='flex flex-wrap gap-5'>
        <FaPhone />
        <p className='text-purple-600 text-xl'>Main Office</p>
          </div>
        
        <p>+345678</p>
        <p>+345678</p>
      </div>
      <div className='my-10 mx-10'>
      <div  className='flex flex-wrap gap-5'>
      <FaPhone />
      <p className='text-purple-600 text-xl'>
        Laboratory Office</p>
        </div>
        
        <p>+345678</p>
        <p>+345678</p>
      </div>
      </div>

    </div>
  )
}

export default HospitalDetailWithOutState
