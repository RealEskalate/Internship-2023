import React from 'react'

const Search: React.FC = () => {
  return (
    <div className="relative mb-3">
            <input
                type="search"
                className="peer block min-h-[auto] w-full border-2 rounded-full bg-transparent px-3 py-[2] leading-[1.6] outline-none transition-all duration-200 ease-linear focus:placeholder:opacity-100 peer-focus:text-primary data-[te-input-state-active]:placeholder:opacity-100 motion-reduce:transition-none dark:text-neutral-200 dark:placeholder:text-neutral-200 dark:peer-focus:text-primary"
                id="exampleSearch2"
                placeholder="Type query" />
    </div>
  )
}

export default Search