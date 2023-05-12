import React from 'react'
import { Blog } from '@/types/blog'
import BlogFooter from '@/components/blog/BlogCardFooter'

interface BlogCardProps {
  blog: Blog
  pageName: 'MyBlogs' | 'RelatedBlogs'
}

const BlogCard: React.FC<BlogCardProps> = ({
  blog: {
    author,
    description,
    datePosted,
    title,
    tags,
    imgUrl,
    likes = 0,
    status = 'pending',
  },
  pageName,
}) => {
  return (
    <div className="w-[400px] font-montserrat flex flex-col border border-gray-300 rounded-lg overflow-hidden shadow-md bg-white h-543 my-8 font-bold">
      <img
        className="w-full h-60 object-cover"
        src={imgUrl}
        alt={author.name}
      />
      <div className="p-4">
        <b>
          <h2 className="font-bold text-lg text-gray-700 break-words overflow-hidden line-clamp-3 leading-snug">
            {title}
          </h2>
        </b>

        <div className="flex items-center mb-6 mt-4">
          <img
            className="w-10 h-10 object-cover rounded-full mr-2"
            src={author.imageUrl}
            alt={author.name}
          />

          <div className="flex flex-col items-start">
            <span className="m-0 text-gray-600 leading-5">
              <b className="font-thin">&nbsp;{' by '}</b>&nbsp;
              <b>{author.name}</b>
              <b className="font-thin">
                &nbsp;&nbsp;{' | '}&nbsp;&nbsp;
                {new Date(datePosted).toLocaleDateString('en-US', {
                  month: 'short',
                  day: 'numeric',
                  year: 'numeric',
                })}
              </b>
            </span>
          </div>
        </div>
        <div className="flex flex-row items-center mb-4">
          {tags.map((tag: string, index: number) => (
            <span
              key={index}
              className="mr-2 px-2 py-1 bg-gray-100 text-gray-500 rounded-full text-xs"
            >
              {tag}
            </span>
          ))}
        </div>
        <p className="mt-3 mb-3 text-sm font-thin text-gray-500 break-words overflow-hidden line-clamp-3 leading-snug">
          {description}
        </p>
        <br />
        <hr className="border-gray-200" />
        <BlogFooter
          numberOfLikes={likes}
          blogStatus={status}
          pageName={pageName}
        />
      </div>
    </div>
  )
}

export default BlogCard
