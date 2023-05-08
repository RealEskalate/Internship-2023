import blogs from '../../data/blogs.json'
import { Blog } from '../../types/blog/blog'

import BlogCard from '../blog/BlogCard'
const MyBlogs: React.FC = () => {
  return (
    <div className="flex flex-col gap-5 mt-4  text-secondary-text">
      <div>
        <div>
          <h1 className="font-semibold text-secondary-text text py-1">
            Manage Blogs
          </h1>
          <p className="text-xs">
            Edit, Delete and View the Status of your blogs
          </p>
        </div>
      </div>
      <hr />

      <div className="grid grid-cols-4 mt-2 gap-8">
        {blogs.map((blog: Blog, index) => {
          return <BlogCard key={index} blog={blog} />
        })}
      </div>
    </div>
  )
}

export default MyBlogs
