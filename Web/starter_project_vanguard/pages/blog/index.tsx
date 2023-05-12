import React, { useEffect } from 'react'
import BlogsCard from '@/components/blog/BlogsCard'
import Search from '@/components/common/Search'
import blogs from '../../data/blogs.json'
import { useState } from 'react'
import Pagination from '@/components/common/pagination'
import { Blog } from '../../types/blog/blog'

const Blogs: React.FC = () => {
  const [currentPage, setCurrentPage] = useState(1)
  const [currentBlogs, setBlogs] = useState(blogs)

  const onPageChange = (page: number) => {
    setCurrentPage(page)
  }
  useEffect(() => {
    const start = (currentPage - 1) * 8
    const end = start + 4
    setBlogs(blogs.slice(start, end))
  }, [currentPage])

  return (
    <div className="font-montserrat justify-center min-h-screen mb-10">
      <div className="h-44 ">
        <Search />
      </div>

      <div>
        <ul>
          {currentBlogs.map((blog: Blog) => (
            <li key={blog._id} className="text-2xl font-bold">
              <BlogsCard blog={blog} />
            </li>
          ))}
          <div className="mt-16">
            <Pagination
              currentPage={currentPage}
              totalPages={Math.ceil(blogs.length / 8)}
              onPageChange={onPageChange}
            />
          </div>
        </ul>
      </div>
    </div>
  )
}

export default Blogs
