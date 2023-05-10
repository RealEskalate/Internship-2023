import BlogCard from '@/components/blog/BlogCard';
import { selectMultipleBlogsByID } from '@/slices/blogs/blogsSlice';
import { useAppSelector } from "@/store/hooks";
import { Blog } from '@/types/blog';

interface RelatedBlogsProps {
  blogs: Blog['relatedBlogs']
}

export const RelatedBlogs: React.FC<RelatedBlogsProps> = ({ blogs }) => {
  const relatedBlogs = useAppSelector(selectMultipleBlogsByID(blogs))

  return (
    <div className='font-montserrat'>

      {/* Title */}
      <div className='text-lg pt-20 flex items-start font-black'>
        <h1>Related Blogs</h1>
      </div>

      {/* Related blogs */}
      <div className='flex items-center gap-8 justify-center mt-6 text-xs'>
        { relatedBlogs.map((blog, index) => <BlogCard blog={blog} key={index} />) }
      </div>

    </div>
  )
}