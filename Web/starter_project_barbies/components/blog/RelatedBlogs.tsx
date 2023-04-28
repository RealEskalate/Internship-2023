import BlogCard from '@/components/blog/BlogCard';
import { Blog } from "@/types/blog";

interface RelatedBlogsProps {
  blog: Blog
}

export const RelatedBlogs: React.FC<RelatedBlogsProps> = ({ blog }) => {
  // Fetch related blogs
  let relatedBlogs: Blog[] = new Array(3).fill(blog);

  return (
    <div className='font-montserrat'>

      {/* Title */}
      <div className='text-lg pt-20 flex items-start font-black'>
        <h1>Related Blogs</h1>
      </div>

      {/* Related blogs */}
      <div className='flex items-center gap-8 justify-center mt-6 text-xs'>
        { relatedBlogs.map((blog) => (BlogCard({ blog }))) }
      </div>

    </div>
  )
}