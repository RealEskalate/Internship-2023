import React, { useState } from 'react'
import PaginationPage from './paginationPage'
import { string } from 'yup'

interface PaginationProps{
    pages: string[]
    currentPage: number
    setCurrentPage: (page: number) => void
}
function Pagination({pages, currentPage, setCurrentPage}: PaginationProps) {

  return (
    <div className='flex p-4 justify-center'>{pages.map((page, index) => <PaginationPage onClick={() => {setCurrentPage(index)}} key={index} page={page} outline={pages[currentPage] === page ? true: false}></PaginationPage>)}</div>
  )
}

export default Pagination