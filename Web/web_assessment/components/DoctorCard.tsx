import Image from 'next/image'
import Link from 'next/link'
import React from 'react'

const DoctorCard = (props:any) => {
  console.log(props,'this is from doctor card')
  console.log(props.item.fullName,'this is')
  return (
    <div>
      
      <Link href={`./doctors/${props.item._id}`} passHref>
       <Image src = {props.item.photo}
        alt = "nothing" width={200}
        height={200}/>
       <h1> {props.item.fullName} </h1>
       <button>
        {props.item.speciality[0].name}
       </button>
       <p>{props.item.mainInstitution.institutionName}</p>
       </Link>
    </div>
  )
}

export default DoctorCard