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
        <div className="bg-white flex pt-16 min-h-screen pl-14">
          <div className="flex flex-wrap justify-center h-20">
            <div className="justify-center pr-14 w-1/4">
              <span className="font-semibold text-4xl">Blogs</span>
            </div>
            <div className="flex pl-80 pb-5 w-2/3">
              <Search />
              <div className="items-center justify-center mt-4 ml-8">
                <div className="w-60 ">
                  <button className="btn btn-lg btn-pill flex mt-2">
                    <i>
                      <span className="text-lg font-semibold">+ New Blog</span>
                    </i>
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
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
