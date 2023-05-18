import BlogCard from '@/components/blog/BlogCard';
import { useGetBlogsQuery } from '@/store/blog/blogs-api';
import { Blog } from '@/types/blog';
import { BlogCardShimmer } from './BlogCardShimmer';

interface RelatedBlogsProps {
  relatedBlogs: Blog['relatedBlogs']
}

export const RelatedBlogs: React.FC<RelatedBlogsProps> = ({ relatedBlogs }): React.ReactElement | null => {
  const { data, isSuccess, isLoading, isError, error } = useGetBlogsQuery()
  
  // In case of error, the component shouldn't be rendered
  if (isError) {
    return <div>{error.toString()}</div>
  }
  
  if (isSuccess || isLoading) {
    return (
      <div className='font-montserrat'>

        {/* Title */}
        <div className='text-lg pt-20 flex items-start font-black'>
          <h1>Related Blogs</h1>
        </div>

        {/* Related blogs */}
        <div className='flex items-center gap-8 justify-center mt-6 text-xs'>
          {/* Render Shimmer component if loading */}
          { isLoading &&
              Array.from({ length: 3 }).map((_, index) => ( <BlogCardShimmer key={index} /> ))}
          {/* Render empty list if result is empty */}
          { (isSuccess && data.length == 0) &&
              <div>No related blogs</div> }
          {/* Render result list if success */}
          { (isSuccess && data.length > 0) && data
              .filter(blog => relatedBlogs.includes(blog.id))
              .map((blog, index) => <BlogCard blog={blog} key={index} />) }
        </div>

      </div>
    )
  }

  return null
}