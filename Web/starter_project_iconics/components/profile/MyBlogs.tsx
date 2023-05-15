import { Blog } from '@/types/blog'
import React from 'react'
import BlogCard from '@/components/blog/BlogCard'
import blogs from '@/data/profile/personal-blogs.json'

const MyBlogs: React.FC = () => {
  const blogsArray: Blog[] = JSON.parse(JSON.stringify(blogs))
  const content = {
    buttonText: 'New Blog',

    bodyMainText: 'Manage Blogs',
    bodyInnerText: 'Edit, Delete and View the Status of your blogs',
    currentPage: 'My Blogs',
  }
  return (
    <div>
      <div className="flex flex-col md:flex-row justify-center my-5 py-4 items-center bg-white">
        <span>
          <h2 className={`text-2xl font-bold text-gray-500`}>
            {content.bodyMainText}
          </h2>
          <h3 className={`text--.1xl text-gray-400`}>
            {content.bodyInnerText}
          </h3>
        </span>
        <div className="flex-1"></div>
        <button className="text-sm font-semibold text-white bg-primary px-8 py-2 rounded-md float-right">
          {content.buttonText}
        </button>
      </div>
      <div className="flex mt-3 justify-between flex-wrap items-center">
        {blogsArray?.map((blog, index) => {
          return <BlogCard blog={blog} key={index} isMyBlogsPage={true} />
        })}
      </div>
    </div>
  )
}

export default MyBlogs
