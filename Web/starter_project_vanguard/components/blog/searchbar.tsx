import { FormEvent } from 'react';

function SearchBar(): JSX.Element {
  const handleFormSubmit = (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();
    const searchTerm = event.currentTarget.search.value;
    // do something with the search term, such as sending it to a search API
    console.log(searchTerm);
  };

  return (
    <form onSubmit={handleFormSubmit}>
      <div className="flex items-center justify-center mt-4">
        <div className="relative text-gray-600">
          <input
            type="search"
            name="search"
            placeholder="Search..."
            className="bg-white h-16 w-256 pl-10 rounded-full text-sm focus:outline-none border border-gray-400"
          />
          <button
            type="submit"
            className="absolute right-0 top-0 mt-3 mr-4"
          >
          </button>
        </div>
      </div>
    </form>
  );
}


export default SearchBar;