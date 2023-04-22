import React from 'react'

function TeamCard() {
    return (
        <div className='flex flex-col bg-white rounded-lg max-w-xs p-4 m-2 items-center justify-center shadow-lg border-none'>
            <img className='rounded-full w-28 h-28 mt-2 object-cover ' src='https://www.dmarge.com/wp-content/uploads/2021/01/dwayne-the-rock-.jpg'></img>
            <h1 className="font-bold uppercase text-[1.5rem] mt-2">nathaniel awel</h1>
            <h2 className="uppercase text-[24]">software engineer</h2>
            <p className="text-center my-4 text-[#7D7D7D]">He is a motivated software engineer looking to pursue a successful career in software development where he can help deliver software solutions to social problems. His skills include Web Development, Data Structures, Machine Learning, and DevOps. Natnael’s hobbies include coding, playing soccer, and watching movies.</p>
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