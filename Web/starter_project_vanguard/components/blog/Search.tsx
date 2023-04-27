import Text from '@/components/common/Text'
import React from 'react'

interface Props {}
const Button: React.FC<Props> = () => {
  return (
    <div className="w-60 ">
      <button className="bg-blue-800 hover:bg-blue-700 text-white py-4 h-16  px-10 rounded-full flex items-center font-montserrat btn-pill">
        <i>
          <Text
            children={'+ New Blog'}
            size="lg"
            weight="semibold"
            family="montserrat"
          />
        </i>
      </button>
    </div>
  )
}

function SearchBar() {
  return (
    <div className="flex items-center justify-center mt-4">
      <div className=" text-gray-600">
        <input
          name="search"
          placeholder="Search..."
          className="bg-white w-96 h-16 pl-10 rounded-full text-lg focus:outline-none border border-gray-400"
        />
      </div>
    </div>
  )
}

function Search() {
  return (
    <div className="bg-white flex pt-16 min-h-screen pl-14 ">
      <div className=" flex flex-wrap justify-center h-20 ">
        <div className="justify-center pr-14 w-1/4">
          <Text children={'Blogs'} weight="semibold" size="4xl" />
        </div>
        <div className="flex pl-80 pb-5 w-2/3">
          <div>
            <SearchBar />
          </div>
          <div className="items-center justify-center mt-4 ml-8">
            <Button />
          </div>
        </div>
      </div>
    </div>
  )
}

export default Search
