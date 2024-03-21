import React from 'react'

function SupportUs() {
  return (
    <div className='mt-32 bg-gradient-to-r to-[#019CFA] from-[#264FAD]'>
        <div className=" p-32 flex flex-col justify-center" 
        style={{
          backgroundImage: "url('/img/home/africa.png')",
          backgroundPosition: "50% 50%",
          backgroundRepeat:"no-repeat",
        }}>
        <p className='text-white w-fit m-auto p-4'>Help us sustain our mission!</p>
        <button className='text-primary font-semibold capitalize bg-white p-2 px-8 rounded m-auto'>Support us</button>

      </div>
    </div>
  )
}

export default SupportUs