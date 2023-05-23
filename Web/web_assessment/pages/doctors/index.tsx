import React from 'react'
import Search from '@/components/doctors/Search'
import DoctorCard from '@/components/doctors/DoctorCard'

const Doctors: React.FC = () => {
  return (
    <div className='flex flex-col items-center mx-2'>
        <Search />
        <div className="flex flex-wrap gap-4 items-center self-center">
          {Array.from({ length: 50 }).map((_, idx) => (<DoctorCard key={idx} id={1} name='  Dr. Biruk Fikadu' specialty='Pediatrician' institution='Washington Medical Center | MCM korean Hospital' photo='/img/doctor.jpg'/>))}
</div>
    </div>
  )
}

export default Doctors