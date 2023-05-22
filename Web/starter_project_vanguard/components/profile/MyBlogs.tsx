import data from '@/data/blog/blogs.json'
import { Blog } from '@/types/blog/blog'
import BlogCard from '@/components/blog/BlogCard'
const MyBlogs: React.FC = () => {
  const blogs = data.blogs
  const handleDelete: (id: string) => void = (id) => {
    null
  }

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

      <div className="grid md:grid-cols-2 grid-cols-1 lg:grid-cols-4 mt-2 gap-8">
        {blogs.map((blog: Blog) => {
          return (
            <BlogCard
              key={blog.id}
              blog={blog}
              isMyBlog={true}
              handleDelete={handleDelete}
            />
          )
        })}
      </div>
    </div>
  )
}

export default MyBlogs
