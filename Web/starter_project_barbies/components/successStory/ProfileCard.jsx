import React from 'react'
import Image from 'next/image'
const ProfileCard = ({personalProfile}) => {
     const paragraphs = [
        {
            title: "My A2SV Experience",
            detail: personalProfile?.experience,
        },
        {
            title: "What I did/I am doing now",
            detail: personalProfile?.achivements,
        },
        {
            title: "How the A2sv Program changed my life",
            detail: personalProfile?.a2svImpact,
        },
    ]

  return (
    <div className='flex flex-row gap-20 mx-20 my-10'>

        <div className = "relative  flex flex-col w-96 h-100">
            <Image src = {personalProfile?.image} className='h-full w-full' alt = {personalProfile?.name}/>
                <div className='absolute flex flex-col gap-2 w-full bottom-0 p-8 rounded-lg shadow-lg backdrop-filter backdrop-blur-lg backdrop-opacity-100 text-white'>
                    <p className='text-2xl font-semibold'>{personalProfile?.name}</p>
                    <p className='font-semibold'>{personalProfile?.profession}</p>
                    <p >{personalProfile?.internPlace}</p>
                </div>
        </div>

        <div className='flex flex-grow flex-col w-64 h-40 gap-7 mt-20'>
            {paragraphs.map((paragraph , index) => {
            
             return (
                <div className = "flex flex-col gap-3 mt-5" key = {index} >
                    <h4 className='font-Montserrat font-medium text-1xl '>{paragraph.title}</h4>
                    <p className='text-xs text-secondarytext'>{paragraph?.detail}</p>
                </div>
             )

            })}
        </div>
      
    </div>
  )
}

export default ProfileCard;
