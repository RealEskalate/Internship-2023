import { Blog } from '@/types/blog'
import React from 'react'
import BlogCard from '@/components/blog/BlogCard'
import blogs from '@/data/profile/personal-blogs.json'

const MyBlogs: React.FC = () => {
  const blogsArray: Blog[] = JSON.parse(JSON.stringify(blogs))

  return (
    <div>
      <div className="flex flex-col md:flex-row justify-center my-5 py-4 items-center bg-white">
        <span>
          <h2 className={`text-2xl font-bold text-gray-500`}>
            {'Manage Blogs'}
          </h2>
          <h3 className={`text--.1xl text-gray-400`}>
            {'Edit, Delete and View the Status of your blogs'}
          </h3>
        </span>
        <div className="flex-1"></div>
        <button className="text-sm font-semibold text-white bg-primary px-8 py-2 rounded-md float-right">
          {'New Blog'}
        </button>
      </div>
      <div className="flex mt-3 justify-between flex-wrap items-center">
        {blogsArray?.map((blog, index) => {
          return <BlogCard blog={blog} key={index} pageName={'MyBlogs'} />
        })}
      </div>
    </div>
  )
}

export default MyBlogs
