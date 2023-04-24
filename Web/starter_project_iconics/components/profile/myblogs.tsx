import { Blog } from '@/types/blog'
import React from 'react'
import BlogCard from '../common/blogCard'

type MyblogsProps = {
  cards: Blog[]
}

const MyBlogs: React.FC<MyblogsProps> = ({ cards }) => {
  return (
    <div className="flex mt-3 justify-between flex-wrap items-center">
      {cards?.map((card, index) => {
        return <BlogCard card={card} key={index} feature="status" />
      })}
    </div>
  )
}

export default MyBlogs
