import { map } from 'cypress/types/bluebird'
import React from 'react'
import Blog from '@/components/blog/blog'
import Search from '@/components/blog/search'

import { useState } from 'react';
import Pagination from '@/components/blog/pagination';


function Blogs() {

  const blogs = [
    <Blog/>,
    <Blog/>,
    <Blog/>,
    <Blog/>,
    <Blog/>,
    <Blog/>,
    
  
]
const [currentPage, setCurrentPage] = useState(1);
const [currentBlogs, setBlogs] = useState(blogs);

const onPageChange = (page: number) => {
  setCurrentPage(page);
};


  return (
    <div className='justify-center min-h-screen mb-10'>
     
      <div className='h-44 '>
      <Search />
     
      </div>
      
     <div>
     <ul>
     {currentBlogs.map((blog) => (
          <li className="text-2xl font-bold">{blog}</li>
      ))}
      <Pagination currentPage={currentPage} totalPages={Math.ceil(blogs.length / 2)} onPageChange={onPageChange} />

        
      </ul>
     </div>
     
    </div>
    
  )
}

export default Blogs