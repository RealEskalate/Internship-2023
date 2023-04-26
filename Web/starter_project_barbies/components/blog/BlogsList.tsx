import { BlogCardWide } from "@/components/blog/BlogCardWide";
import { Blog } from "@/types/blog";

interface BlogsProps {
  blogs: Blog[]
}

export const BlogsList: React.FC<BlogsProps> = ({ blogs }) => {
  return (
    <div className='bg-white text-primary-text'>
      { blogs.map((blog, index) => <BlogCardWide blog={blog} key={index} />) }
    </div>
  )
}
