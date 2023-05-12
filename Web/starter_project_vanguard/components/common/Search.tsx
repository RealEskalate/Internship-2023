import React from 'react'

const Search: React.FC = () => {
  return (
    <div className="bg-white flex pt-16 min-h-screen pl-14">
      <div className=" flex flex-wrap justify-center h-20 ">
        <div className="justify-center pr-14 w-1/4">
          <span className="font-semibold text-4xl">Blogs</span>
        </div>
        <div className="flex pl-80 pb-5 w-2/3">
          <div>
            <div className="flex items-center justify-center mt-4">
              <div className=" text-gray-600">
                <input
                  name="search"
                  placeholder="Search..."
                  className="bg-white w-96 h-16 pl-10 rounded-full text-lg focus:outline-none border border-gray-400"
                />
              </div>
            </div>
          </div>
          <div className="items-center justify-center mt-4 ml-8">
            <div className="w-60 ">
              <button className="btn btn-lg btn-pill flex mt-2">
                <i>
                  <span className="text-lg font-semibold ">+ New Blog</span>
                </i>
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  )
}

export default Search
