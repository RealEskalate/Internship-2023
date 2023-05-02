import React from 'react'
import Image from 'next/image'
import google from './../../public/img/story/companies/google.png'
import palantir from './../../public/img/story/companies/palantir.png'
import instaDeep from './../../public/img/story/companies/instdeep.png'
import meta from './../../public/img/story/companies/meta.png'
import databricks from './../../public/img/story/companies/databricks.png'
import linkedin from './../../public/img/story/companies/linkedin.png'


const Partners = () => {

const logos = [google, palantir, instaDeep, meta, databricks, linkedin]

  return (
    <div className='flex flex-col text-center text-40 lg:mt-20 lg:mx-0 md:mt-40'>
        <h2 className='font-DM Sans mr-40 lg:mr-20 md:mr-10 text-3xl'>Current Interview Partners</h2>
        <div className='flex flex-wrap mx-80 lg:mx-60  md:mx-5  justify-evenly gap-5 text-2xl mt-20'>
            {logos.map((logo , index)=>
            <div key={index} className='w-40 mb-5'>
                <Image src = {logo} alt = "logo"/>
                </div>
             )}
        </div>
    </div>
  )
}

export default Partners
