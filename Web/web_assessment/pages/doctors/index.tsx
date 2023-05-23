import DoctorCard from '@/components/DoctorCard';
import { useSearchDoctorsQuery } from '@/store/features/doctorsapi';
import React, { ChangeEvent, useEffect, useState } from 'react'

const page1 = () => {
  const [searchTerm, setSearchTerm] = useState('');
  
  const { data: response } = useSearchDoctorsQuery(searchTerm);
  const doctors = response?.data || [];
  console.log(doctors)
  
  useEffect(() => {
    if (!searchTerm) {
      
      setSearchTerm('');
    }
  }, [searchTerm]);

  const handleSearchChange = (event: ChangeEvent<HTMLInputElement>) => {
    setSearchTerm(event.target.value);
  };
  


  return (
    <div className = "min-h-screen  m-auto">
      <input
              type="search"
              id="search"
              className="block w-1/2 m-auto px-4 mt-14 text-2xl  border-l-2 outline-none border-primary font-montserrat"
              placeholder="Search by name or specialty"
              required
              value={searchTerm}
              onChange={handleSearchChange}
            />
      
      <div className="grid grid-cols-1 gap-10 mt-10 mb-14 md:grid-cols-4">
          {doctors.map((item: string) => (
            // <BlogCard key = "item" id={item} />
            <DoctorCard item = {item}/>
          ))}
      </div>
    </div>
  )
}

export default page1