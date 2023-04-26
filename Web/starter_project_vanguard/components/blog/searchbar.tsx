import { FormEvent } from 'react';

function SearchBar() {
//   const handleFormSubmit = (event: FormEvent<HTMLFormElement>) => {
//     event.preventDefault();
//     const searchTerm = event.currentTarget.search.value;
//     // do something with the search term, such as sending it to a search API
//     console.log(searchTerm);
//   };

  return (
    // <form onSubmit={handleFormSubmit}>
        
      <div className="flex items-center justify-center mt-4">
        <div className=" text-gray-600">
          <input
            // type="search"
            name="search"
            placeholder="Search..."
    
            className="bg-white w-96 h-16 pl-10 rounded-full text-lg focus:outline-none border border-gray-400"
          />
        
        </div>
      </div>
    // </form>
  );
}


export default SearchBar;