import React, { useState } from "react"

interface PaginationProps {
  numberOfPages: number
}

interface PaginationItemProps {
  pageNumber: number
  isCurrentPage: boolean
  onPageClick: React.Dispatch<React.SetStateAction<number>>
}

export const Pagination: React.FC<PaginationProps> = ({ numberOfPages }) => {
  const [currentPage, setCurrentPage] = useState(1)

  let paginationItems = []
  for (let i = 1; i <= numberOfPages; i++) {
    let paginationItem = <PaginationItem pageNumber={i} isCurrentPage={i == currentPage} onPageClick={setCurrentPage} />
    paginationItems.push(paginationItem)
  }

  return (
    <div className="flex bg-white px-4 py-12 flex-1 justify-center">
      <nav className="flex gap-3 text-xs font-medium">
        {paginationItems}
      </nav>
    </div>
  )
}

const PaginationItem: React.FC<PaginationItemProps> = ({ pageNumber, isCurrentPage, onPageClick }) => {
  return (
    <button
      className={`${"rounded h-8 w-8 " + (isCurrentPage ? "bg-primary text-white" : "bg-gray-200 text-black")}`}
      onClick={() => { onPageClick(pageNumber) }}
    >
      {pageNumber}
    </button>
  )
}
