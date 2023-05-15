import React from 'react'

const Search: React.FC = () => {
  return (
    <div>
      <div className="flex items-center justify-center mt-4">
        <div className="text-gray-600">
          <input
            name="search"
            placeholder="Search..."
            className="bg-white w-96 h-16 pl-10 rounded-full text-lg focus:outline-none border border-gray-400"
          />
        </div>
      </div>
    </div>
  )
}

export default Search
