import DoctorCard from '@/components/DoctorCard';
import { useSearchDoctorsQuery } from '@/store/features/doctorsapi';
import React, { ChangeEvent, useEffect, useState } from 'react'

const DoctorsList:React.FC = () => {
  const [searchTerm, setSearchTerm] = useState('');
  
  const { data: response,isLoading } = useSearchDoctorsQuery(searchTerm);
  const doctors = response?.data || [];
  
  
  useEffect(() => {
    if (!searchTerm) {
      
      setSearchTerm('');
    }
  }, [searchTerm]);

  const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };
  


  return (
    <div className = "bg-white  m-auto">
      <input
              type="search"
              id="search"
              className="block rounded-full w-1/2 m-auto px-4 mt-14 text-2xl  border-2 outline-none border-primary font-montserrat"
              placeholder="Search by name or specialty"
              required
              value={searchTerm}
              onChange={handleSearchChange}
            />
      
      <div className="grid grid-cols-1 gap-4 w-4/5 m-auto mt-10 mb-14 md:grid-cols-4">
          {doctors.map((item: string) => (
            <DoctorCard item = {item}/>
          ))}
      </div>
    </div>
  )
}

export default DoctorsList