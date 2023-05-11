import BlogCard from '@/components/blog/BlogCard';
import { useGetBlogsQuery } from '@/store/blog/blogs-api';
import { Blog } from '@/types/blog';

interface RelatedBlogsProps {
  blogs: Blog['relatedBlogs']
}

export const RelatedBlogs: React.FC<RelatedBlogsProps> = ({ blogs }) => {

  const result = useGetBlogsQuery()

  let content

  if (result.isLoading) {
    content = <div>Loading...</div>
  }
  
  else if (result.isError) {
    content = <div>{result.error.toString()}</div>
  }
  
  else if (result.isSuccess) {
    content = result.data
      .filter(blog => blogs.includes(blog.id))
      .map((blog, index) => <BlogCard blog={blog} key={index} />)
  }

  return (
    <div className='font-montserrat'>

      {/* Title */}
      <div className='text-lg pt-20 flex items-start font-black'>
        <h1>Related Blogs</h1>
      </div>

      {/* Related blogs */}
      <div className='flex items-center gap-8 justify-center mt-6 text-xs'>
        { content }
      </div>

    </div>
  )
}