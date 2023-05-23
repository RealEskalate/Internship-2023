import React from 'react';

type PaginationProp = {
    itemsPerPage: number;
    totalItems: number;
    paginate: (pageNumber: number) => void;
    currentPage: number;
};

const Pagination: React.FC<PaginationProp> = ({ itemsPerPage, totalItems, paginate, currentPage }: PaginationProp) => {
    return (
        <nav aria-label="Page navigation example">
            <ul className="list-style-none flex">
                <li>
                    <a className="pointer-events-none relative block rounded bg-transparent px-3 py-1.5 text-sm text-gray-500 transition-all duration-300 dark:text-gray-400">Previous</a>
                </li>
                <li>
                    <a className="relative block rounded border border-gray-300 bg-transparent px-3 py-1.5 text-sm text-indigo-500 transition-all duration-300 hover:bg-gray-100 dark:text-white dark:hover:bg-gray-700 dark:hover:text-white" href="#!">1</a>
                </li>
                <li aria-current="page">
                    <a className="relative block rounded bg-indigo-500 border-gray-300 border px-3 py-1.5 text-sm font-medium text-white transition-all duration-300" href="#!">
                        2
                        <span className="absolute -m-px h-px w-px overflow-hidden whitespace-nowrap border-0 p-0 [clip:rect(0,0,0,0)]">(current)</span>
                    </a>
                </li>
                <li>
                    <a className="relative block rounded border border-gray-300 bg-transparent px-3 py-1.5 text-sm text-indigo-500 transition-all duration-300 hover:bg-gray-100 dark:text-white dark:hover:bg-gray-700 dark:hover:text-white" href="#!">3</a>
                </li>
                <li>
                    <a className="relative block rounded bg-transparent px-3 py-1.5 text-sm text-indigo-500 transition-all duration-300 dark:text-indigo-500" href="#!">Next</a>
                </li>
            </ul>
        </nav>
    );
};

export default Pagination;
