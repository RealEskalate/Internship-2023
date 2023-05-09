import React from 'react'
import Image from 'next/image'

const partnerSection = [
  {imgurl:"google-logo.png" , 
  alternative:"Google logo"},
  {imgurl:"palantir-logo.png" , 
  alternative:"Palantir logo"},
  {imgurl:"inst-deep-logo.png" , 
  alternative:"Instdeep logo"},
  {imgurl:"meta-logo.png" , 
  alternative:"Meta logo"},
  {imgurl:"databricks-logo.png" , 
  alternative:"Databricks logo"},
  {imgurl:"linkedin-logo.png" , 
  alternative:"linkedin logo"},
]

const PartnerLogos: React.FC = () => {
  return (
    <div className="max-w-screen-lg">
        <h2 className="text-4xl font-semibold text-center mb-6 mt-8 font-DMSans">Current Interview Partners</h2>
        <div className="flex flex-wrap  justify-around items-center  ">
          {partnerSection.map((data) => (
            <div key={data.imgurl} className="w-52 h-36 flex justify-center items-center bg-white rounded-full">
              <Image width={251} height={110} src={`/img/success-stories-images/companies/${data.imgurl}`}alt={data.alternative} />
            </div>
            
          ))}
        </div>    
      </div>
  )
}

export default PartnerLogos
