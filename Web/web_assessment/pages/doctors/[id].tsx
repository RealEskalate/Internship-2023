import { useGetDoctorProfileQuery } from '@/store/features/doctorsapi'
import Image from 'next/image'
import { useRouter } from 'next/router'
import React from 'react'

const DetailsPage:React.FC = () => {
  const router = useRouter()
  let { id } = router.query
  id = id as string
  
  const {data:blog,isLoading} = useGetDoctorProfileQuery(id)
  if (isLoading){
    return <div> loading ... </div>
  }
  if (!blog) {
    return <div>Blog not found</div>;
  }
  
  return (
    
    <div className='block w-3/4 m-auto mt-20 bg-white'>
      <div className='relative'>
        <Image
        src = "/img/Group 8823.png"
        alt = "group 3388"
        width = {1000}
        height={400}
        />
        <Image 
        className='rounded-full m-auto absolute top-1/2 left-1/3'
        src = {blog.photo} 
        alt = "photo"
        width = {200}
        height={200}
        />
      </div>
      
      <div className='mt-32'>
        <h2> {blog.fullName} </h2>
        <p> {blog.speciality[0].name}</p>
        <p> {blog.institutionID_list[0].address.region}</p>
        <p> {blog.institutionID_list[0].institutionName} </p>
      </div>

      <div className='mt-14 mb-10'>
        <h2 className = "bold mt-8"> About </h2>
        <p>{blog.institutionID_list[0].lang.am.summary}</p>
      </div>

      <div className="flex justify-between mb-10" >
        <div className="flex flex-col gap-y-1">
          <h1 className="text-xl font-bold">
            Addis Ababa University
          </h1>
          <span className="text-base">B. Sc Medicine</span>
        </div>
        <p className="font-light text-2xl">2003 - 2007</p>
      </div>
      <div className="flex justify-between mb-10" >
        <div className="flex flex-col gap-y-1">
          <h1 className="text-xl font-bold">
            Harvard University
          </h1>
          <span className="text-base">B. Sc Medicine</span>
        </div>
        <p className="font-light text-2xl">2003 - 2007</p>
      </div>

      <div className="mb-12">
        <h1 className="text-lg font-bold mb-12">Contact Info</h1>
        <div>
          
          <h1 className="inline text-lg text-primary">Phone Number:</h1>
        </div>
        <p className="ml-10">+25111763498</p>
      </div>

      <div className="pb-12">
        <div>
          
          <h1 className="inline text-lg text-primary">Email:</h1>
        </div>
        <p className="ml-10">fasiltefera@stpaul.com</p>
      </div>
      
    </div>
  )
}

export default DetailsPage