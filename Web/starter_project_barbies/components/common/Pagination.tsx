import React from "react"

interface PaginationItemProps {
	pageNumber: number
	isCurrentPage: boolean
}

interface PaginationProps {
	numberOfPages: number
}

const PaginationItem: React.FC<PaginationItemProps> = ({pageNumber, isCurrentPage}) => {
  return (
    <button
      className={`
        ${isCurrentPage ?
						"rounded bg-blue-600 h-8 w-8 text-center leading-8 text-white"
            : "rounded bg-gray-200 h-8 w-8 text-center leading-8 text-black"}
      `}
    >
      {pageNumber}
    </button>
  )
}

export const Pagination: React.FC<PaginationProps> = ({numberOfPages}) => {
	{/* Hardcoded to be on the first page */}
	let currentPage = 1

	let paginationItems = []
	for (let i = 1; i <= numberOfPages; i++) {
		let paginationItem = <PaginationItem pageNumber={i} isCurrentPage={i == currentPage} />
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
