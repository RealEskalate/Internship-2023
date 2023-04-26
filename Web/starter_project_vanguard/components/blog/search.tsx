import SearchBar from '@/components/blog/searchbar'
import Text from '@/components/blog/text'
import React from 'react'
import Button from './addbutton'

function Search() {
  return (
    <div className='bg-white flex pt-52 min-h-screen pl-14 '>
        
    <div className=' flex flex-wrap justify-center h-20 '>
        <div className='justify-center pr-14 w-1/4'>
        <Text children={'Blogs'} weight='semibold' size='4xl' />

        </div>
        <div className='flex pl-44 pb-5 w-2/3'>
          <div>
          <SearchBar />
          </div>
          <div className='items-center justify-center mt-4 ml-8'>
          <Button />
          </div>
        
        
        </div>
    </div>
       
     </div>
  )
}

export default Search