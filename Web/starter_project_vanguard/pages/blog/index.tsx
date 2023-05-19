import BlogsCard from '@/components/blog/BlogsCard'
import Search from '@/components/common/Search'
import Pagination from '@/components/common/pagination'
import React, { useEffect, useState } from 'react'
import { Blog } from '@/types/blog/blog'
import { useGetBlogsQuery } from '@/store/features/blog/blogs-api'
import Link from 'next/link'

const Blogs: React.FC = () => {
  const { data: blogs = [], isFetching, isError } = useGetBlogsQuery({})

  const [currentPage, setCurrentPage] = useState(1)
  const [currentBlogs, setBlogs] = useState(blogs)

  const onPageChange = (page: number) => {
    setCurrentPage(page)
  }

  useEffect(() => {
    const start = (currentPage - 1) * 8
    const end = start + 4
    setBlogs(blogs.slice(start, end))
  }, [currentPage])

  useEffect(() => {
    setBlogs(blogs)
  }, [blogs])

  if (isFetching) {
    return (
      <div className=" h-screen flex justify-center items-center">
        <div
          className="inline-block h-8 w-8 animate-spin rounded-full border-4 border-solid border-current border-r-transparent align-[-0.125em] motion-reduce:animate-[spin_1.5s_linear_infinite]"
          role="status"
        >
          <span className="!absolute !-m-px !h-px !w-px !overflow-hidden !whitespace-nowrap !border-0 !p-0 ![clip:rect(0,0,0,0)]">
            Loading...
          </span>
        </div>
      </div>
    )
  }
  if (isError) {
    return (
      <section className="flex items-center h-full p-16 dark:bg-gray-900 dark:text-gray-100">
        <div className="container flex flex-col items-center justify-center px-5 mx-auto my-8">
          <div className="max-w-md text-center">
            <h2 className="mb-8 font-extrabold text-9xl dark:text-gray-600">
              <span className="sr-only">Error</span>404
            </h2>
            <p className="text-2xl font-semibold md:text-3xl">
              Sorry, we couldn&apos;t find this page.
            </p>
            <p className="mt-4 mb-8 dark:text-gray-400">
              But dont worry, you can find plenty of other things on our
              homepage.
            </p>
            <Link
              rel="noopener noreferrer"
              href="/"
              className="px-8 py-3 font-semibold rounded dark:bg-violet-400 dark:text-gray-900"
            >
              Back to homepage
            </Link>
          </div>
        </div>
      </section>
    )
  }

  return (
    <div className="font-montserrat justify-center min-h-screen mb-10">
      <div className="h-44">
        <div className="bg-white flex pt-16 min-h-screen pl-14">
          <div className="flex flex-wrap justify-center h-20">
            <div className="justify-center pr-14 w-1/4">
              <span className="font-semibold text-4xl">Blogs</span>
            </div>
            <div className="flex pl-80 pb-5 w-2/3">
              <Search />
              <div className="items-center justify-center mt-4 ml-8">
                <div className="w-60">
                <Link href={`./blog/add-new-blog`} passHref>
                  <button className="btn btn-lg btn-pill flex mt-2">
                    <i>
                      <span className="text-lg font-semibold">+ New Blog</span>
                    </i>
                  </button>
                </Link>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>

      <div>
        <ul>
          {currentBlogs.map((blog: Blog) => (
            <li key={blog.id} className="text-2xl font-bold">
              <BlogsCard blog={blog} />
            </li>
          ))}
          <div className="mt-16">
            <Pagination
              currentPage={currentPage}
              totalPages={Math.ceil(blogs.length / 8)}
              onPageChange={onPageChange}
            />
          </div>
        </ul>
      </div>
    </div>
  )
}

export default Blogs
