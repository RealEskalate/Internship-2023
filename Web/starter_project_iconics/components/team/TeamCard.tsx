import React from 'react'

export interface TeamCardProps{
    name: string
    job: string
    description: string
    instagram?: string
     linkedin?: string
     facebook?: string
     avatar?: string
}

function TeamCard({name, job, description, avatar = 'https://www.dmarge.com/wp-content/uploads/2021/01/dwayne-the-rock-.jpg', instagram, linkedin, facebook}: TeamCardProps) {
    return (
        <div className='flex flex-col bg-white rounded-lg p-4 m-2 items-center justify-center shadow-lg'>
            <img className='rounded-full w-28 h-28 mt-2 object-cover ' src={avatar}></img>
            <h1 className="font-bold uppercase text-[1.5rem] mt-2">{name}</h1>
            <h2 className="uppercase text-[24]">{job}</h2>
            <p className="text-center my-4 text-[#7D7D7D]">{description}</p>
            <hr className='my-2 w-[100%] '></hr>

            <div className="flex justify-around w-[100%]">
                
                    <a href=""><img className='rounded-md object-contain w-6' src='./facebook.png'></img></a>
              
                <a href=''>
                    <img className='rounded-md object-contain w-6' src='./instagram.png'></img>
                </a>
                <a href=''>
                    <img className='rounded-md object-contain w-6' src='./linkedin.png'></img>
                </a>

            </div>
        </div>
    )
}

export default TeamCard