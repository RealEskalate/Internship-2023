import { useGetDoctorProfileQuery } from '@/store/features/doctorsapi'
import Image from 'next/image'
import { useRouter } from 'next/router'
import React from 'react'

const page2 = () => {
  const router = useRouter()
  let { id } = router.query
  id = id as string
  console.log(id)
  const {data:blog,isLoading} = useGetDoctorProfileQuery(id)
  if (isLoading){
    return <div> loading ... </div>
  }
  if (!blog) {
    return <div>Blog not found</div>;
  }
  console.log(blog)
  return (
    
    <div className='block w-3/4 m-auto mt-28 min-h-screen'>
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

      <div className='mt-14'>
        <h2 className = "bold mt-8"> About </h2>
        <p>{blog.institutionID_list[0].lang.am.summary}</p>
      </div>
      
    </div>
  )
}

export default page2