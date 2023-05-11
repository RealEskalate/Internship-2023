import React from 'react'
import { ServiceDescription } from '../../types/home'

function ServicesCard({serviceDescription}:{serviceDescription:ServiceDescription}) {
  return (
    <div  className={serviceDescription.is_left ? 'flex justify-between flex-row-reverse text-left pt-40 px-28': 'flex justify-between text-right pt-40 px-28'}>
        <div className="hidden md:block bg-cover  rounded-full  w-60 h-60 bg-[url('/img/home/success-description.png')]" >
            <div className="md:w-60 md:h-60 rounded-full border-8 border-darkwhite border-opacity-40">
              
            </div>
          </div>

          <div className=" px">
            <h1 className="font-bold capitalize text-3xl pb-8 ">{serviceDescription.title}</h1>
            <p className=' max-w-md w-fit  text-secondarytext'>{serviceDescription.description}</p>
          </div>
    </div>
  )
}

export default ServicesCard