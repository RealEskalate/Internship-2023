import { BlogsList } from "@/components/blog/BlogsList";
import { Pagination } from "@/components/common/Pagination";
import { SearchForm } from "@/components/common/SearchForm";
import { useGetBlogsQuery } from "@/store/blog/blogs-api";

const Blogs = () => {
  const result = useGetBlogsQuery()

  let content

  if (result.isLoading) {
    content = <div>loading...</div>
  } else if (result.isError) {
    content = <div>{result.error.toString()}</div>
  } else if (result.isSuccess) {
    content = <BlogsList blogs={result.data} />
  }

  return (
    <div className='bg-white text-primary-text font-montserrat'>

      {/* Title and search bar */}
      <div className="flex justify-center pt-20">
        <div className='grid grid-cols-3 mt-2 w-full'>
          <div className="flex items-center">
            <div className='ps-28 text-xl font-semibold'>
              Blogs
            </div>
          </div>
          <div className='flex justify-center'>
            <SearchForm />
          </div>
          <div />
        </div>
      </div>

      {/* Blog list */}
      <div className="mt-10 px-56">
        { content }
      </div>

      {/* Pagination */}
      <Pagination numberOfPages={5} />

    </div>
  )
}

export default Blogs;