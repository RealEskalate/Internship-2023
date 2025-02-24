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
