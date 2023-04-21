import React, { useState } from "react"

interface PaginationItemProps {
	pageNumber: number
	isCurrentPage: boolean,
	onClick: React.Dispatch<React.SetStateAction<number>>
}

interface PaginationProps {
	numberOfPages: number
}

const PaginationItem: React.FC<PaginationItemProps> = ({pageNumber, isCurrentPage, onClick}) => {
  return (
    <button
      className={`
        ${isCurrentPage ?
						"rounded bg-blue-600 h-8 w-8 text-center leading-8 text-white"
            : "rounded bg-gray-200 h-8 w-8 text-center leading-8 text-black"}
      `}
			onClick={() => {onClick(pageNumber)}}
    >
      {pageNumber}
    </button>
  )
}

export const Pagination: React.FC<PaginationProps> = ({numberOfPages}) => {
	const [currentPage, setCurrentPage] = useState(1)

	let paginationItems = []
	for (let i = 1; i <= numberOfPages; i++) {
		let paginationItem = <PaginationItem pageNumber={i} isCurrentPage={i == currentPage} onClick={setCurrentPage} />
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
