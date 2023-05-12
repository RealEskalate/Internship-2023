import BlogTile from '@/components/blog/BlogTile'
import { useGetBlogsQuery } from '@/store/features/api/blog-api'
import Link from 'next/link'
import { FaPlus } from 'react-icons/fa'

const Blogs = () => {
  const { data: blogsData, isLoading } = useGetBlogsQuery()
  console.log(blogsData)

  if (isLoading) {
    return <div className="m-auto">Loading...</div>
  }
  return (
    <div className="bg-white pt-4 text-primary-text">
      <div className="flex flex-col items-center gap-y-4 mt-5 mx-10 md:flex-row">
        <h1 className="text-xl font-bold">Blogs</h1>
        <form className="flex gap-4 m-auto">
          <input
            id="search"
            type="text"
            placeholder="search"
            className="w-48 p-3 text-secondary-text rounded-3xl text-sm border-0 shadow outline-none focus:outline-none focus:ring "
          />
          <button className="bg-primary text-white text-sm p-3 rounded-3xl">
            <FaPlus className="inline text-sm m-2" />
            New Blog
          </button>
        </form>
      </div>

      <section>
        {blogsData?.map((blog, index) => (
          <Link key={index} href={'blog/' + blog.id}>
            <BlogTile {...blog} />
          </Link>
        ))}
      </section>
    </div>
  )
}

export default Blogs
