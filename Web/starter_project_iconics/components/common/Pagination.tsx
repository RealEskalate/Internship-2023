interface PaginationProps{
    pagesCount: number
    currentPage: number
    setCurrentPage: (page: number) => void
}

const Pagination : React.FC<PaginationProps> = ({pagesCount, currentPage, setCurrentPage}) => {
  let pages: JSX.Element[] = []
  const visible = 2

  for (let page:number = 1; page <= pagesCount; page++) {
    
    if (page <= visible || page > pagesCount-visible || (currentPage-visible <= page && currentPage+visible >= page)) {
      pages.push( <button onClick={() => setCurrentPage(page)} className={`${currentPage === page? 'bg-primary text-secondary': 'bg-secondary text-primary'} m-1 px-3 py-2 rounded-md cursor-pointer`}>{page}</button>)
    }
    else{
      pages.push( <button className={`flex text-primary m-1 px-3 py-2 rounded-md items-center cursor-pointer`} disabled>{'...'}</button>)
      page = page < currentPage ? currentPage-(visible+1) : pagesCount - visible
    }
  }
  
  return (
    <div className='flex flex-wrap p-4 justify-center'> 
    {pages}
    </div>
  )
}

export default Pagination