
interface PaginationProps{
    pagesCount: number
    currentPage: number
    setCurrentPage: (page: number) => void
}
interface paginationPageProps{
  page: string,
  onClick?:  () => void,
  active?: boolean
}
function PaginationPage({page, onClick, active}: paginationPageProps) {
  return (

      <button onClick={onClick} className={`${active? 'bg-primary text-secondary': 'bg-secondary text-primary'} m-1 px-3 py-2 rounded-md cursor-pointer`}>{page}</button>

  )
}


function Pagination({pagesCount, currentPage, setCurrentPage}: PaginationProps) {

  let pages: string[] = []

  for (let page = 1; page <= pagesCount; page++) {
    pages.push(page.toString())
  }

  return (
    <div className='flex p-4 justify-center'> {pages.map((page, index) => <PaginationPage key={index} onClick={() => {setCurrentPage(index)}} page={page} active={pages[currentPage] === page ? true: false}></PaginationPage>)}</div>
  )
}

export default Pagination