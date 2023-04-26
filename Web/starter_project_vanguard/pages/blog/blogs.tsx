import { map } from 'cypress/types/bluebird'
import React from 'react'
import Blog from '@/components/blog/blog'
import Search from '@/components/blog/search'
import Button  from '@/components/blog/addbutton'

const blogs = [
    <Blog/>,
    <Blog />,
    <Blog/>,
    <Blog />,
    <Blog/>,
    <Blog />,
]

function Blogs() {
  return (
    <div className='justify-center'>
      
      <div className='h-80'>
      <Search />
     
      </div>
      
     <div className='pt-4'>
     <ul>
        {blogs.map((item) => (
            <li>{item}</li>
        ))}
      </ul>
     </div>
     
    </div>
    
  )
}

export default Blogs