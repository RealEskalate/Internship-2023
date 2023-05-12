import BlogCard from '@/components/blog/BlogCard';
import { useGetBlogsQuery } from '@/store/blog/blogs-api';
import { Blog } from '@/types/blog';
import { BlogCardLoading } from './BlogCardLoading';

interface RelatedBlogsProps {
  blogs: Blog['relatedBlogs']
}

export const RelatedBlogs: React.FC<RelatedBlogsProps> = ({ blogs }): React.ReactElement | null => {
  const result = useGetBlogsQuery();
  
  if (result.isError) {
    return null
  }
  
  else if (result.isSuccess || result.isLoading) {
    return (
      <div className='font-montserrat'>

        {/* Title */}
        <div className='text-lg pt-20 flex items-start font-black'>
          <h1>Related Blogs</h1>
        </div>

        {/* Related blogs */}
        <div className='flex items-center gap-8 justify-center mt-6 text-xs'>
          {/* Render Shimmer component if loading */}
          { result.isSuccess &&
              Array.from({ length: 3 }).map((_, index) => ( <BlogCardLoading key={index} /> ))}
          {/* Render result list if success */}
          { result.isSuccess && result.data
              .filter(blog => blogs.includes(blog.id))
              .map((blog, index) => <BlogCard blog={blog} key={index} />) }
        </div>

      </div>
    )
  }

  return null
}