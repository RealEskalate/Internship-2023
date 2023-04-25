import clsx from 'clsx'
import React from 'react'
interface paginationPageProps{
  page: string,
  onClick?:  () => void,
  active?: boolean
}
function PaginationPage({page, onClick, active}: paginationPageProps) {
  return (

      <button onClick={onClick} className={clsx(active? 'bg-primary text-white': 'bg-[#E1E7EC]', 'm-1 px-3 py-2 rounded-md cursor-pointer')}>{page}</button>

  )
}

export default PaginationPage