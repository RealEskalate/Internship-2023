import React, { useState } from "react";

interface PaginationProps {
  numberOfPages: number;
}

interface PaginationItemProps {
  pageNumber: number;
  isCurrentPage: boolean;
  onPageClick: (pageNumber: number) => void;
}

export const Pagination: React.FC<PaginationProps> = ({ numberOfPages }) => {
  const [currentPage, setCurrentPage] = useState(1);

  const handlePageClick = (pageNumber: number) => {
    setCurrentPage(pageNumber);
  };

  const paginationItems = [];
  for (let i = 1; i <= numberOfPages; i++) {
    const paginationItem = (
      <PaginationItem
        key={i}
        pageNumber={i}
        isCurrentPage={i === currentPage}
        onPageClick={handlePageClick}
      />
    );
    paginationItems.push(paginationItem);
  }

  return (
    <div className="flex bg-white px-4 py-12 flex-1 justify-center">
      <nav className="flex gap-3 text-xs font-medium">
        {paginationItems}
      </nav>
    </div>
  );
};

const PaginationItem: React.FC<PaginationItemProps> = ({
  pageNumber,
  isCurrentPage,
  onPageClick,
}) => {
  const handleClick = () => {
    onPageClick(pageNumber);
  };

  return (
    <button
      className={`rounded h-8 w-8 ${
        isCurrentPage ? "bg-primary text-white" : "bg-gray-200 text-black"
      }`}
      onClick={handleClick}
    >
      {pageNumber}
    </button>
  );
};
