import Image from 'next/image'
import Link from 'next/link'
import React from 'react'

const DoctorCard:React.FC<any> = (props) => {

  return (
    <div className='bg-white-500 shadow-lg pt-4 text-center'>
      
      <Link href={`./doctors/${props.item._id}`} passHref>
       <Image src = {props.item.photo}
        alt = "nothing" width={100}
        height={100}
        className = "rounded-full mx-auto"/>
        <div>
       <h1> {props.item.fullName} </h1>
       <button className = "bg-indigo-500 rounded-full">
        {props.item.speciality[0].name}
       </button>
       <p>{props.item.mainInstitution.institutionName}</p>
       </div>
       </Link>
    </div>
  )
}

export default DoctorCard