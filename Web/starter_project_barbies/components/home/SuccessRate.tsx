import React from 'react'
import AcceptanceCard from './AcceptanceCard'
import acceptanceRate from '../../public/data/home/acceptance-rate.json'
import serviceDescription from '../../public/data/home/service-description.json'
import ServicesCard from './ServiceCard'
function SuccessRate() {
  return (
    <div>
        <div>
          <h1 className=" pt-32 pb-16 font-bold text-3xl capitalize text-center">
          Google SWE Interviews Acceptance <br></br> Rate Comparison
          </h1>
          <div>
            <div className='grid  md:grid-cols-2 lg:grid-cols-5 gap-8 bg-darktonewhite p-6 py-10 rounded-2xl'>
              <p className=' col-span-2 lg:col-span-1 text-secondarytext md:h-40 rounded-2xl p-6 '>
              A2SV students are <b className='inline-flex text-primarytext'>35 </b> times more likely to pass <b className='inline-flex text-primarytext'>Google SWE interviews </b> than average candidates.
              </p>
              {
                acceptanceRate.map(single =>{
                  return (
                    <AcceptanceCard key = {single.id} acceptanceDescription = {single}/>
                  )
                })
              }

            </div>
          </div>
        </div> 
          {
            serviceDescription.map(single =>{
              return (
                <ServicesCard key={single.id} serviceDescription = {single}/>
              )
            })
            
          } 
    </div>
  )
}

export default SuccessRate