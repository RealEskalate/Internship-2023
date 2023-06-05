import React from 'react';

const SearchBar: React.FC = () => {
  return (
    <div className='bg-white'>
      <input type="text" placeholder="Search" className='rounded-full w-2/3 h-10 mt-10 ml-40 pl-[20px] border-2'/>
    </div>
  );
};

export default SearchBar;
