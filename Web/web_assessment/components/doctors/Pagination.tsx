import React from 'react';

type PaginationProp = {
    itemsPerPage: number;
    totalItems: number;
    paginate: (pageNumber: number) => void;
    currentPage: number;
};

const Pagination: React.FC<PaginationProp> = ({ itemsPerPage, totalItems, paginate, currentPage }: PaginationProp) => {
    const totalPages = Math.ceil(totalItems / itemsPerPage);
    const pageNumbers = Array.from({ length: totalPages }, (_, index) => index + 1);

    return (
        <nav aria-label="Page navigation example">
            <ul className="list-style-none flex">
                <li>
                    <a
                        className="pointer-events-none relative block rounded bg-transparent px-3 py-1.5 text-sm text-gray-500 transition-all duration-300 dark:text-gray-400"
                    >
                        Previous
                    </a>
                </li>
                {pageNumbers.map((pageNumber) => (
                    <li key={pageNumber}>
                        <a
                            className={`relative block rounded border border-gray-300 bg-transparent px-3 py-1.5 text-sm ${
                                pageNumber === currentPage ? 'text-black bg-indigo-500' : 'text-indigo-500'
                            } transition-all duration-300 hover:bg-indigo-500 hover:text-white text-black`}
                            href="#!"
                            onClick={() => paginate(pageNumber)}
                        >
                            {pageNumber}
                        </a>
                    </li>
                ))}
                <li>
                    <a
                        className="relative block rounded bg-transparent px-3 py-1.5 text-sm text-indigo-500 transition-all duration-300 dark:text-indigo-500"
                        href="#!"
                    >
                        Next
                    </a>
                </li>
            </ul>
        </nav>
    );
};




export default Pagination;
