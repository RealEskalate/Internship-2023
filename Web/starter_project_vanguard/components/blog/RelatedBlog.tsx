import { useGetSingleBlogQuery } from '@/store/features/blog/single-blog-api';
import BlogCard from '@/components/blog/BlogCard'
import React from 'react'

interface Props{
  id:string;
}

const RelatedBlogCard:React.FC<Props> = (props) => {
  const {data:blog,isLoading} = useGetSingleBlogQuery(props.id)
  if (isLoading){
    return <div> is loading </div>
  }
  if (!blog) {
    return <div>Blog not found</div>;
  }
 
  return (
    <div>
      <BlogCard blog = {blog}/>
    </div>
  )
}

export default RelatedBlogCard