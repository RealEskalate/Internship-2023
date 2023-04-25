import { BlogCardWide } from "@/components/blog/BlogCardWide";
import { Pagination } from "@/components/common/Pagination";
import { Blog } from "@/types/blog";
import React from "react";
import { AiOutlinePlus } from 'react-icons/ai';

interface BlogsScreenProps {
  blogs: Blog[]
}

export const BlogsScreen: React.FC<BlogsScreenProps> = ({ blogs }) => {
  return (
    <div className='bg-white text-black font-montserrat'>

      <div className="flex justify-center pt-20">
        <div className='grid grid-cols-3 mt-2 w-full'>

          {/* Title and search bar */}
          <div className="flex items-center">
            <div className='ps-28 text-xl font-black'>
              Blogs
            </div>
          </div>
          <div className='flex justify-center'>
            <SearchForm />
          </div>
          <div />

        </div>
      </div>

      {/* Blog list */}
      <div className="mt-10 px-56">
        <BlogsList blogs={blogs} />
      </div>

      {/* Pagination */}
      <Pagination numberOfPages={5} />

    </div>
  )
}

const BlogsList: React.FC<BlogsScreenProps> = ({ blogs }) => {
  let blogComponents = []
  let key = 0
  for (let blog of blogs) {
    blogComponents.push(<BlogCardWide blog={blog} key={key++} />)
  }

  return (
    <div className='bg-white text-black'>
      {blogComponents}
    </div>
  )
}

const SearchForm = () => {
  return (
    <form className="flex gap-4">

      <input type="text" className="border border-gray-300 text-gray-900 text-sm rounded-full block px-8 py-2.5 w-60" placeholder="Search..." />
      
      <button type="submit" className="text-white bg-blue-600 font-black rounded-full text-sm px-5 py-2.5 text-center">
        <AiOutlinePlus className="inline-block me-1" />
        New Blog
      </button>
      
    </form>
  )
}
