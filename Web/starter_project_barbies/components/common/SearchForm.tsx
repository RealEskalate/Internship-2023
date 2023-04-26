import { AiOutlinePlus } from 'react-icons/ai';

export const SearchForm = () => {
  return (
    <form className="flex gap-4">

      {/* Search input */}
      <input type="text" className="border border-gray-300 text-gray-900 text-sm rounded-full block px-8 py-2.5 w-60" placeholder="Search..." />
      {/* Search button */}
      <button type="submit" className="text-white bg-primary font-medium rounded-full text-sm px-5 py-2.5 text-center">
        <AiOutlinePlus className="inline-block me-1" />
        New Blog
      </button>
      
    </form>
  )
}
