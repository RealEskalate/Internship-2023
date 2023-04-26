import React from 'react'
import google from './../../public/img/successStory/google.png'
import palantir from './../../public/img/successStory/palantir.png'
import instaDeep from './../../public/img/successStory/instDeep.png'
import meta from './../../public/img/successStory/meta.png'
import databricks from './../../public/img/successStory/databricks.png'
import linkedin from './../../public/img/successStory/linkedin.png'
import Image from 'next/image'

const Partners = () => {
    const logos = [google, palantir, instaDeep, meta, databricks, linkedin]
  return (
    <div className='flex flex-col text-center font-poppins m-50 text-40'>
        <h2 className='font-DM Sans text-3xl'>Current Interview Partners</h2>
        <div className='flex flex-wrap mx-60 my-10 justify-evenly gap-5 text-2xl'>
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
