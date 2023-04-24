import clsx from 'clsx'
import React from 'react'
interface paginationPageProps{
  page: string,
  onClick?:  () => void,
  outline?: boolean
}
function PaginationPage({page, onClick, outline}: paginationPageProps) {
  return (

      <button onClick={onClick} className={clsx(outline? 'outline outline-1 outline-[#264FAD]  bg-white text-[#264FAD]': 'text-white', 'm-1 px-3 py-2 bg-[#264FAD] rounded-md cursor-pointer')}>{page}</button>

  )
}

export default PaginationPage