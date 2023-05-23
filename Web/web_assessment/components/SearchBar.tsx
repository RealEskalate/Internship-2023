import React, { useState } from 'react';
import { useSearchDoctorsQuery } from '@/store/features/doctors/doctors-api';
import DoctorCard from './DoctorCard'
interface SearchResult {
  id: number;
  title: string;
}

const SearchBar: React.FC = () => {
  const [searchTerm, setSearchTerm] = useState<string>('');
  const { data: doctors, isLoading, isError } = useSearchDoctorsQuery(searchTerm);

  const handleSearch = (event: React.FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    // Call the search API with the current search term
    setSearchTerm(event.currentTarget.search.value);
  };

  return (
    <div className="flex flex-col items-center">
      <form onSubmit={handleSearch} className="w-full max-w-sm">
        <div className="flex items-center border-2 border-teal-500 py-2">
          <input
            className="appearance-none bg-transparent border-none w-full text-gray-700 mr-3 py-1 px-2 leading-tight focus:outline-none"
            type="text"
            name="search"
            placeholder="Search..."
          />
          <button
            className="flex-shrink-0 bg-teal-500 hover:bg-teal-700 border-teal-500 hover:border-teal-700 text-sm border-4 text-white py-1 px-2 rounded"
            type="submit"
          >
            Search
          </button>
        </div>
      </form>
      {isLoading && <div>Loading...</div>}
      {isError && <div>Error fetching search results</div>}
      {Array.isArray(doctors) && doctors.map((doctor:any) => (
    <DoctorCard key= {doctor._id} id = {doctor._id} photoUrl={doctor.photo} name={doctor.fullName} specialty="pedrasan" address="addis ababa"/>
  ))}
        
      
    </div>
  );
};

export default SearchBar;
