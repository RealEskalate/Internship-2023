import React, { useState } from 'react';
import { useFetchUserByKeywordQuery } from '@/features/userSlice';
import Link from 'next/link';
import Card from './Card';

const Search = () => {
  const [keyword, setKeyword] = useState('');
  const { data, isLoading, isError } = useFetchUserByKeywordQuery(keyword);

  const handleSearch = (e: React.ChangeEvent<HTMLInputElement>) => {
    setKeyword(e.target.value);
  };

  return (
    <div>
      <input type="text" className="w-full  mx-auto border border-2 my-5 p-3 outline-none rounded-lg" placeholder='Name' value={keyword} onChange={handleSearch} />
      {(
        <div className='grid lg:grid-cols-4 md:grid-cols-3 sm:grid-cols-2 mt-5 gap-3'>
          {data &&
            data.data.map((doctor: any) => (
              <Link key={doctor._id} href={`/detail/${doctor._id}`}>
                <Card
                  fullName={doctor.fullName}
                  photo={doctor.photo}
                  speciality={doctor.speciality[0].name}
                  address={doctor.institutionID_list[0].institutionName}
                />
              </Link>
            ))}
        </div>
      )}
    </div>
  );
};

export default Search;
