import React from 'react'
import { AcceptanceRate } from '../../types/home'
function AcceptanceCard({acceptanceDescription}:{acceptanceDescription:AcceptanceRate}) {
  return (
    <div>
        <div className='md:h-40 rounded-2xl shadow-md p-6 items-center bg-white flex flex-col justify-between'>
                <p className='font-bold'>{acceptanceDescription.year}</p> 
                <div>
                <p className='font-bold capitalize p-2 w-fit m-auto'>{acceptanceDescription.passed}</p>
                <p className='text-secondarytext'>{acceptanceDescription.average}% average</p>
                </div>
              </div>
    </div>
  )
}

export default AcceptanceCard