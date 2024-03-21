import React from 'react'
import {AiOutlineMessage} from "react-icons/ai"
import buildBetter from "../../public/img/home/build-better.png"
import Image from 'next/image'
const BuildBetter = () => {
  return (
    <div>
      <div className="flex gap-6 flex-col items-center">
            <h1 className="font-bold text-3xl capitalize text-center ">Lets build a better <br></br> tomorrow</h1>
            <p className='text-center text-secondarytext' >
            A2SV upskills high-potential university students, connects them with opportunities at top tech companies around the world, and creates digital solutions to urgent problems in their home countries. The program is free for students, making the opportunity available for youth who have talent but lack the means to use it.
            </p>
            <button className='bg-primary p-2 rounded text-white px-4'>
              <AiOutlineMessage className='inline mr-2'></AiOutlineMessage>
                Connect to our team
            </button>
            <div>
              <Image className=' object-contain' src={buildBetter} alt="build better"></Image>
            </div>
        </div>
        
    </div>
  )
}

export default BuildBetter