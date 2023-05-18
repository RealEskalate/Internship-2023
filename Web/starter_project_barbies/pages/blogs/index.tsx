import { BlogCardWide } from "@/components/blog/BlogCardWide";
import { BlogCardWideShimmer } from "@/components/blog/BlogCardWideShimmer";
import { Pagination } from "@/components/common/Pagination";
import { SearchForm } from "@/components/common/SearchForm";
import { useGetBlogsQuery } from "@/store/blog/blogs-api";

const Blogs = () => {
  const { data, isSuccess, isLoading, isError, error } = useGetBlogsQuery()
  
  if (isError) {
    return <div>Error: {error.toString()}</div>
  }
  
  if (isSuccess || isLoading) {
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
          <div className='bg-white text-primary-text'>
            {/* Render Shimmer component if loading */}
            { isLoading &&
                Array.from({ length: 3 }).map((_, index) => ( <BlogCardWideShimmer key={index} /> )) }
            {/* Render blogsResult list if success */}
            { isSuccess && data
                .map((blog, index) => <BlogCardWide blog={blog} key={index} />) }
          </div>
        </div>

        {/* Pagination */}
        <Pagination numberOfPages={5} />

      </div>
    )
  }
}

export default Blogs;