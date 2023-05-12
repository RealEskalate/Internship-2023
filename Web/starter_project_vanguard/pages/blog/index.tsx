import BlogsCard from '@/components/blog/BlogsCard'
import Search from '@/components/common/Search'
import Pagination from '@/components/common/pagination'
import React, { useEffect, useState } from 'react'
import blogs from '../../data/blogs.json'
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
      <div className="h-44">
        <Search title={'Blogs'} />
      </div>

      <div>
        <ul>
          {currentBlogs.map((currentBlog: Blog) => (
            <li key={currentBlog._id} className="text-2xl font-bold">
              <BlogsCard blog={currentBlog} />
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
