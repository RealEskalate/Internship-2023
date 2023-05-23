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
      <input type="text" className="w-full border border-2" value={keyword} onChange={handleSearch} />
      {keyword && (
        <div>
          {data &&
            data.data.map((item: any) => (
              <Link key={item._id} href={`/detail/${item._id}`}>
                <Card
                  fullName={item.fullName}
                  photo={item.photo}
                  speciality={item.speciality[0].name}
                  address={item.institutionID_list[0].institutionName}
                />
              </Link>
            ))}
        </div>
      )}
    </div>
  );
};

export default Search;
