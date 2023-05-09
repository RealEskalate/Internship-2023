import React from 'react'
import { Blog } from '../../types/profile/blog'
import BlogFooter from './BlogCardFooter'

interface Props {
  blog: Blog
  isMyBlogsPage: boolean
}

const BlogCard: React.FC<Props> = ({ blog, isMyBlogsPage }) => {
  return (
    <div className="blog w-[400px] font-montserrat flex flex-col border border-gray-300 rounded-lg overflow-hidden shadow-md bg-white h-543 my-8 font-bold">
      <img
        className="w-full h-60 object-cover"
        src={blog.photoUrl}
        alt={`${blog.writter.firstName} ${blog.writter.lastName}`}
      />
      <div className="p-4">
        <b>
          <h2 className="blog_title font-bold text-lg text-gray-700 break-words overflow-hidden line-clamp-3 leading-snug">
            {blog.title}
          </h2>
        </b>

        <div className="blog_writter flex items-center mb-6 mt-4">
          <img
            className="blog_writter_image w-10 h-10 object-cover rounded-full mr-2"
            src={blog.writter.photoUrl}
            alt={`${blog.writter.firstName} ${blog.writter.lastName}`}
          />

          <div className="blog_writter_details flex flex-col items-start">
            <span className="blog_writter_name m-0   text-gray-600 leading-5">
              <b className="font-thin">&nbsp;{' by '}</b>&nbsp;
              <b>
                {blog.writter.firstName} {blog.writter.lastName}
              </b>
              <b className="font-thin">
                &nbsp;&nbsp;{' | '}&nbsp;&nbsp;
                {new Date(blog.datePosted).toLocaleDateString('en-US', {
                  month: 'short',
                  day: 'numeric',
                  year: 'numeric',
                })}
              </b>
            </span>
          </div>
        </div>
        <div className="blog_tags flex flex-row items-center mb-4">
          {blog.tags.map((tag, index) => (
            <span
              key={index}
              className="blog_tag mr-2 px-2 py-1 bg-gray-100 text-gray-500 rounded-full text-xs"
            >
              {tag}
            </span>
          ))}
        </div>
        <p className="blog_description mt-3 mb-3 text-sm font-thin text-gray-500 break-words overflow-hidden line-clamp-3 leading-snug">
          {blog.description}
        </p>
        <br />
        <hr className="line border-gray-200" />
        <BlogFooter
          numberOfLikes={blog.likes}
          blogStatus={blog.status}
          myBlog={isMyBlogsPage}
        />
      </div>
    </div>
  )
}

export default BlogCard
