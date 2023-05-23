// create a footer component wich have log of differnt social media and bg-blue


import React from 'react'

const Footer = () => {
    return (
        <div className='flex flex-col pr-10 bg-primary border-b-2 border-gray-100'>

        <div className="flex items-center justify-between  p-4 bg-primary border-b-2 border-gray-100">
            <div className="flex justify-around items-center w-full">
                
                <h1 className="text-2xl font-semibold text-white">HakimHub</h1>
                <div className="flex gap-4">
                    <div className='flex flex-col gap-1'>
                    <h1 className=' text-white font-semibold'>Get Connected</h1>
                    <p className=' text-white'>&gt; For Physicians</p>
                    <p className=' text-white'>&gt; For Hospitals</p>
                    </div>
                    <div className='flex flex-col'>
                    <h1 className=' text-white font-semibold'>Actions</h1>
                    <p className=' text-white'>&gt; For Physicians</p>
                    <p className=' text-white'>&gt; For Hospitals</p>
                    </div>
                    <div className='flex flex-col '>
                    <h1 className=' text-white font-semibold'>&gt; Company</h1>
                    <p className=' text-white'>&gt; For Physicians</p>
                    <p className=' text-white'>&gt; For Hospitals</p>
                    </div>
            </div>
            

            </div>
            
        </div>
        <hr className='w-full h-1 '/>
        <p className=' text-white pr-10'>Privacy Policy</p>
        </div>

    )
}

export default Footer