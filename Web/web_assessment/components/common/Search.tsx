import React, { ChangeEvent } from "react";
import { CiSearch } from "react-icons/ci";


interface SearchProps{
  keyWord: string
  setKeyWord: (_keyword: string) => void
}

const Search: React.FC<SearchProps> = ({setKeyWord, keyWord}) => {
  const handleSetKeyWord = (e: ChangeEvent<HTMLInputElement>) => {
    setKeyWord(e.target.value)
  }
  return (
    <div className="relative w-3/4 md:w-1/2 flex shrink-1 items-center m-2 p-2 mx-auto">
      <CiSearch className="absolute w-4 h-4 right-6 text-dimtext"></CiSearch>
      <input
        className="border bg-bgprimary h-10 w-full rounded-full px-8 py-1"
        type="text"
        placeholder="Name"
        value={keyWord}
        onChange={handleSetKeyWord}
      ></input>
    </div>
  );
};

export default Search;

// import React from 'react'

// const Search = () => {
//   return (
//     <div><form>   
//     <label htmlFor="default-search" className="mb-2 text-sm font-medium text-gray-900 sr-only dark:text-white">Search</label>
//     <div className="relative">
//         <div className="absolute inset-y-0 left-0 flex items-center pl-3 pointer-events-none">
//             <svg aria-hidden="true" className="w-5 h-5 text-gray-500 dark:text-gray-400" fill="none" stroke="currentColor" viewBox="0 0 24 24" xmlns="http://www.w3.org/2000/svg"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M21 21l-6-6m2-5a7 7 0 11-14 0 7 7 0 0114 0z"></path></svg>
//         </div>

//         <input type="search" id="default-search" className="block w-full border-b-amber-950 shadow-md p-4 pl-10 text-sm border-black dark:border-gray-600 dark:placeholder-gray-400 dark:text-white dark:focus:ring-blue-500 dark:focus:border-blue-500" placeholder="" required/>
//         <button type="submit" className="text-white absolute right-2.5 bottom-2.5 bg-blue-700 hover:bg-blue-800 focus:ring-4 focus:outline-none focus:ring-blue-300 font-medium rounded-lg text-sm px-4 py-2 dark:bg-blue-600 dark:hover:bg-blue-700 dark:focus:ring-blue-800">Search</button>

//     </div>
// </form></div>
//   )
// }

// export default Search