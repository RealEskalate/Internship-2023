import React from 'react';

interface Props {
  currentPage: number;
  totalPages: number;
  onPageChange: (page: number) => void;
}



const Pagination: React.FC<Props> = ({ currentPage, totalPages, onPageChange }) => {
  const range = (start: number, end: number) =>
    Array.from({ length: end - start + 1 }, (_, i) => i + start);

  const pages = range(1, totalPages);

  return (
    <div className="flex justify-center mt-4">
      <nav className="block ">
        <ul className="flex pl-0 rounded-md list-none flex-wrap mb-10">
          {pages.map((page) => (
            <li key={page}>
              <button
                className={`${
                  currentPage === page
                    ? 'bg-primary text-white'
                    : 'text-primary-text hover:text-primary bg-gray-300'
                } font-bold py-2 px-4 border border-gray-300  rounded mx-2  mb-10`}
                onClick={() => onPageChange(page)}
              >
                {page}
              </button>
            </li>
          ))}
        </ul>
      </nav>
    </div>
  );
};

export default Pagination;
