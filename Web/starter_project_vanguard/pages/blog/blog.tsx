import ProfilePic from '@/components/blog/profilepic';
import Description from '@/components/profile/description';
import Name from '@/components/profile/name';
import Title from '@/components/profile/title';
import Text from '@/components/common/text';
import React from 'react'
import 'tailwindcss/base.css';
import Image from '@/components/blog/image';
import Tags from '@/components/blog/chip';
function Blog() {
  return (

    
    <div className="bg-white flex flex-wrap justify-center   ">
      <div className='flex border-b-2 justify-center w-3/4 border-gray-400'>
      <div className="w-3/5 p-4">
      <div className="flex items-start">
        <div className="items-start my-4"> <ProfilePic /> </div>
        <div className="self-center mx-3"> <Name /> </div>
        <div className='items-end self-center mx-5'>
       <Text  size="sm" family="montserrat" children={'April 20'} color="black" weight='light' ></Text>

      </div>
      
      </div>
      
      <div className="flex flex-wrap">
        <div> <Title /> </div>
        <div> <Description /> </div>
      </div>
      <div className="justify-start items-end">
        <Tags tags={["Development", "UI/UX"]} />
      </div>

      </div>

      <div className="flex justify-center items-center w-1/4 p-3 pl-0">
      <Image className="w-6/5" src="https://cdn.pixabay.com/photo/2021/08/04/13/06/software-developer-6521720_960_720.jpg"  borderRadius="rounded-lg" />
      </div>

      </div>
  
      
      </div>

      

     

    
  )
}

export default Blog