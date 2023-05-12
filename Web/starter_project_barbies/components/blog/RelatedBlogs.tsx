import BlogCard from '@/components/blog/BlogCard';
import { useGetBlogsQuery } from '@/store/blog/blogs-api';
import { Blog } from '@/types/blog';
import { BlogCardShimmer } from './BlogCardShimmer';

interface RelatedBlogsProps {
  relatedBlogs: Blog['relatedBlogs']
}

export const RelatedBlogs: React.FC<RelatedBlogsProps> = ({ relatedBlogs }): React.ReactElement | null => {
  const result = useGetBlogsQuery();
  
  if (result.isError) {
    return null
  }
  
  if (result.isSuccess || result.isLoading) {
    return (
      <div className='font-montserrat'>

        {/* Title */}
        <div className='text-lg pt-20 flex items-start font-black'>
          <h1>Related Blogs</h1>
        </div>

        {/* Related blogs */}
        <div className='flex items-center gap-8 justify-center mt-6 text-xs'>
          {/* Render Shimmer component if loading */}
          { result.isLoading &&
              Array.from({ length: 3 }).map((_, index) => ( <BlogCardShimmer key={index} /> ))}
          {/* Render result list if success */}
          { result.isSuccess && result.data
              .filter(blog => relatedBlogs.includes(blog.id))
              .map((blog, index) => <BlogCard blog={blog} key={index} />) }
        </div>

      </div>
    )
  }

  return null
}