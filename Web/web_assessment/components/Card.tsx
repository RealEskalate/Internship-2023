import Image from 'next/image'
import React from 'react'
interface CardProps {
    photo?: string,
    fullName?: string,
    speciality?: string,
    address?: string
}
const Card:React.FC<CardProps> = ({photo="https://res.cloudinary.com/hakimhub/image/upload/v1656314302/POP_DATA_DOC/Addis_Cardiac_Hospital_0.jpg",
 fullName="Dr.Mussie Abera", speciality="peditrician", address="Addis Ababa Bole"}) => {
  return (
    <div className='w-[350px] h-[400px] ' >
        <div className='flex flex-col gap-1 p-3 shadow-md rounded-md'>
        <Image src={photo} alt={fullName} width={100} height={100} className='rounded-full mx-auto'/>
        <h1 className='mx-auto'> {fullName}</h1>
        <p className='mx-auto'>{speciality}</p>
        <address className='mx-auto'>{address}</address>
        </div>
    </div>
  )
}

export default Card