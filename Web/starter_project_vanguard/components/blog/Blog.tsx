import ProfilePic from '@/components/blog/ProfilePic';
import Text from '@/components/blog/Text'
import React from 'react'
import 'tailwindcss/base.css';
import Image from '@/components/blog/Image';
import Tags from '@/components/blog/Chip';
import Name from './Name';
import Title from './Title';
import Description from './Description';
function Blog() {
  return (

    
    <div className=" flex flex-wrap justify-center w-6/5 ">
      <div className='flex border-t-2  w-3/4 border-gray-300 pl-10'>
      <div className=" items-start w-3/5 pt-4 pb-4 pr-0">
      <div className="flex items-start">
        <div className="items-start my-4 mx-0"> <ProfilePic /> </div>
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

      <div className="flex justify-center items-center w-1/4 pl-0 ">
      <Image className="w-6/5" src="https://cdn.pixabay.com/photo/2021/08/04/13/06/software-developer-6521720_960_720.jpg"  borderRadius="rounded-lg" />
      </div>

      </div>
  
      
      </div>

      

     

    
  )
}

export default Blog