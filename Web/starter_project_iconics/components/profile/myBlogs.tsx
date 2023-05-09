import { BlogData } from '@/types/blog/blog'
import React from 'react'
import BlogCard from '@/components/blog/BlogCard'
import blogs from '@/data/profile/blogs.json'

const MyBlogs: React.FC = () => {
  const blogsArray: BlogData[] = JSON.parse(JSON.stringify(blogs))
  return (
    <div className="flex mt-3 justify-between flex-wrap items-center">
      {blogsArray?.map((blog, index) => {
        return <BlogCard blog={blog} key={index} isMyBlogsPage={true} />
      })}
    </div>
  )
}

export default MyBlogs
