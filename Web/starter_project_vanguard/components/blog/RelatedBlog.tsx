import BlogCard from './BlogCard'
import Blogs from '../../data/blogs.json'
import { Blog } from '@/types/blog/blog'
import React from 'react'

interface Props{
  id:string;
}

const RelatedBlogCard:React.FC<Props> = (props) => {
 
  const blog =  Blogs.blogs.filter((item:Blog) => item.id === props.id)[0]
  
  return (
    <div>
      <BlogCard blog = {blog}/>
    </div>
  )
}

export default RelatedBlogCard