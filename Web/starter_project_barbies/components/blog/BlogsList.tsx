import { BlogCardWide } from "@/components/blog/BlogCardWide";
import { Blog } from "@/types/blog";

interface BlogsProps {
  blogs: Blog[]
}

export const BlogsList: React.FC<BlogsProps> = ({ blogs }) => {
  let blogComponents = blogs.map((blog, index) => <BlogCardWide blog={blog} key={index} />)

  return (
    <div className='bg-white text-primary-text'>
      {blogComponents}
    </div>
  )
}