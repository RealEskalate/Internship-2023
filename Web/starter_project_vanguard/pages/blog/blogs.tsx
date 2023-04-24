import ProfilePic from '@/components/blog/profilepic';
import Description from '@/components/profile/description';
import Name from '@/components/profile/name';
import Title from '@/components/profile/title';
import React from 'react'
import 'tailwindcss/base.css';
import Image from '@/components/blog/image';
import Tags from '@/components/blog/chip';
function Blogs() {
  return (

    
    <div className="bg-white flex flex-wrap justify-center ">
      
      <div className="w-1/2 p-4">
      <div className="flex flex-wrap">
        <div > <ProfilePic /> </div>
        <div className="flex justify-center items-center mx-3"> <Name /> </div>
      </div>
      
      <div className="flex flex-wrap">
        <div> <Title /> </div>
        <div> <Description /> </div>
      </div>
      <div className="justify-start items-end">
        <Tags tags={["Development", "UI/UX"]} />
      </div>

      </div>

      <div className="flex justify-center items-center w-1/3 p-4">
      <Image src="https://media.wired.com/photos/598e35fb99d76447c4eb1f28/16:9/w_2123,h_1194,c_limit/phonepicutres-TA.jpg"  borderRadius="rounded-lg" />
      </div>

      
      </div>

      

     

    
  )
}

export default Blogs